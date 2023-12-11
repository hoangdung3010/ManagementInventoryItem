using MT.Library.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library
{
    public static class FileHelper
    {
        /// <summary>
        /// Kích thước mỗi lần đọc để mã hóa
        /// </summary>
        public static int ChunkSize = 1024 * 1024;

        /// <summary>
        /// Hàm mã hóa file
        /// </summary>
        /// <param name="srcFilename">File nguồn</param>
        /// <param name="destFilename">File đích</param>
        public static void EncryptFile(string srcFilename, string destFilename)
        {
            StringBuilder builder = new StringBuilder();
            using (FileStream InputVideoFile = new FileStream(srcFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (FileStream EncryptedVideoFile = new FileStream(destFilename, FileMode.Create))
                {
                    byte[] Buf = new byte[ChunkSize];
                    int ReadBytes;
                    long nTotalReadBytes = 0;
                    while ((ReadBytes = InputVideoFile.Read(Buf, 0, Buf.Length)) > 0)
                    {
                        byte[] EncryptedData = AesCryptoService.Encrypt(Buf, ReadBytes);
                        EncryptedVideoFile.Write(EncryptedData, 0, EncryptedData.Length);
                        nTotalReadBytes += ReadBytes;
                        builder.AppendLine($"{ReadBytes}|{EncryptedData.Length}|{nTotalReadBytes}");
                    }
                }
            }
            //Tạo file mapping
            var folder = System.IO.Path.GetDirectoryName(destFilename);
            string fileNameMapingEncryptWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(destFilename);
            string fileNameMapingEncrypt = System.IO.Path.Combine(folder, $"{fileNameMapingEncryptWithoutExtension}.map");
            using (FileStream stream = new FileStream(fileNameMapingEncrypt, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    //Tạo ra file mapping tương ứng
                    streamWriter.WriteLine(builder.ToString());
                }
            }
        }

        /// <summary>
        /// Hàm giải mã
        /// </summary>
        /// <param name="srcFilename">File nguồn</param>
        /// <param name="destFilename">File đích</param>
        public static void DecryptFile(string srcFilename, string destFilename)
        {
            var folder = System.IO.Path.GetDirectoryName(srcFilename);
            string fileNameMapingEncryptWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(srcFilename);
            string fileNameMapingEncrypt = System.IO.Path.Combine(folder, $"{fileNameMapingEncryptWithoutExtension}.map");

            if (!System.IO.File.Exists(fileNameMapingEncrypt))
            {
                return;
            }

            string[] lines = System.IO.File.ReadAllLines(fileNameMapingEncrypt);
            List<FileInfoEncrypt> infos = new List<FileInfoEncrypt>();
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var split = line.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                infos.Add(new FileInfoEncrypt { OriginBytesLength = int.Parse(split[0]), NewBytesLength = int.Parse(split[1]), TotalReadBytes = long.Parse(split[2]) });
            }
            using (FileStream inputEncrypt = new FileStream(srcFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (FileStream outputDecrypt = new FileStream(destFilename, FileMode.Create))
                {
                    int ReadBytes;
                    long nTotalReadBytes = 0;
                    int i = 0;
                    FileInfoEncrypt fileInfoEncrypt = infos[0];
                    byte[] Buf = new byte[fileInfoEncrypt.NewBytesLength];
                    while ((ReadBytes = inputEncrypt.Read(Buf, 0, fileInfoEncrypt.NewBytesLength)) > 0)
                    {
                        fileInfoEncrypt = infos[i];
                        i++;
                        byte[] decryptData = AesCryptoService.Decrypt(Buf, ReadBytes);
                        outputDecrypt.Write(decryptData, 0, decryptData.Length);
                        nTotalReadBytes += ReadBytes;

                    }
                }
            }
        }


        /// <summary>
        /// Hàm giải mã
        /// </summary>
        /// <param name="srcFilename">File nguồn</param>
        /// <param name="destFilename">File đích</param>
        public async static Task<long> DecryptFile(string srcFilename, Stream outputStream)
        {
            string hashMD5 = Utility.CreateMD5(srcFilename);
            List<FileInfoEncrypt> infos = CacheManager.Get<List<FileInfoEncrypt>>(hashMD5);
            if (infos == null || infos.Count == 0)
            {
                var folder = System.IO.Path.GetDirectoryName(srcFilename);
                string fileNameMapingEncryptWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(srcFilename);
                string fileNameMapingEncrypt = System.IO.Path.Combine(folder, $"{fileNameMapingEncryptWithoutExtension}.map");

                if (!System.IO.File.Exists(fileNameMapingEncrypt))
                {
                    return 0;
                }

                string[] lines = System.IO.File.ReadAllLines(fileNameMapingEncrypt);
                infos = new List<FileInfoEncrypt>();
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    var split = line.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    infos.Add(new FileInfoEncrypt { OriginBytesLength = int.Parse(split[0]), NewBytesLength = int.Parse(split[1]), TotalReadBytes = int.Parse(split[2]) });
                }
            }
            long length = 0;
            using (FileStream inputEncrypt = new FileStream(srcFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                int ReadBytes;
                long nTotalReadBytes = 0;
                int i = 0;
                FileInfoEncrypt fileInfoEncrypt = infos[0];
                byte[] Buf = new byte[fileInfoEncrypt.NewBytesLength];
                length = inputEncrypt.Length;
                while ((ReadBytes = inputEncrypt.Read(Buf, 0, fileInfoEncrypt.NewBytesLength)) > 0)
                {
                    fileInfoEncrypt = infos[i];
                    i++;
                    byte[] decryptData = AesCryptoService.Decrypt(Buf, ReadBytes);
                    await outputStream.WriteAsync(decryptData, 0, decryptData.Length);
                    nTotalReadBytes += ReadBytes;
                }
            }

            return length;
        }

        /// <summary>
        /// Hàm băm md5 file
        /// </summary>
        /// <param name="fileName">Tên file</param>
        /// <returns>Trả về mã md5</returns>
        public static string MD5File(string fileName)
        {
            string md5hash = "";
            try
            {
                long fileSize = new FileInfo(fileName).Length;
                int bufferSize = fileSize > 1048576L ? 1048576 : 4096;
                using (MD5 md = MD5.Create())
                {
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
                    {
                        md5hash = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "");
                    }
                }
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex, ex.Message);
            }

            return md5hash;
        }

        /// <summary>
        /// Hàm thực hiện xóa file
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            try
            {
                //Xóa video cũ đi
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch
            {
                //todo
            }
        }

        /// <summary>
        /// Hàm thay đổi mã md5 của file
        /// </summary>
        /// <param name="fileName">Tên file</param>
        /// <returns>Trả về mã md5</returns>
        public static string ChangeMD5File(string fileName)
        {
            string md5hash = "";
            Random random = new Random();
            int num = random.Next(2, 7);
            byte[] extraByte = new byte[num];
            for (int j = 0; j < num; j++)
            {
                extraByte[j] = (byte)0;
            }
            long fileSize = new FileInfo(fileName).Length;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Append))
            {
                fileStream.Write(extraByte, 0, extraByte.Length);
            }
            int bufferSize = fileSize > 1048576L ? 1048576 : 4096;
            using (MD5 md = MD5.Create())
            {
                using (FileStream fileStream2 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
                {
                    md5hash = BitConverter.ToString(md.ComputeHash(fileStream2)).Replace("-", "");
                }
            }
            return md5hash;
        }
    }
}
