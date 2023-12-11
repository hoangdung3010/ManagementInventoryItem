using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library
{
    public static class AesCryptoService
    {
        private static byte[] Key = Encoding.ASCII.GetBytes(@"qwr{@^h`h&_`50/ja9!'dcmh3!uw<&=?");
        private static byte[] IV = Encoding.ASCII.GetBytes(@"9/\~V).A,lY&=t2b");

        public static byte[] Encrypt(byte[] input, int size)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("input empty");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;


            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.Zeros;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(input, 0, size);
                        csEncrypt.FlushFinalBlock();

                        encrypted = new byte[msEncrypt.Length];
                        msEncrypt.Position = 0;
                        msEncrypt.Read(encrypted, 0, encrypted.Length);
                    }
                }
            }

            return encrypted;
        }

        public static byte[] Decrypt(byte[] input, int size)
        {
            if (input == null || input.Length <= 0)
                throw new ArgumentNullException("input empty");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] output = new byte[size];

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.Zeros;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(input))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        csDecrypt.Read(output, 0, size);
                    }
                }
            }

            return output;
        }


        /// <summary>
        /// Giải mã chuỗi đầu vào
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Decrypt(string input)
        {
            string str = string.Empty;

            try
            {
                if (input == null || input.Length <= 0)
                    throw new ArgumentNullException("input empty");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");
                byte[] buffer = System.Convert.FromBase64String(input);
                byte[] output = new byte[buffer.Length];

                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.Zeros;
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(buffer))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            csDecrypt.Read(output, 0, output.Length);
                        }
                    }
                }
                str = Encoding.Unicode.GetString(output);
                str = str.Replace("\0", "");
            }
            catch 
            {

            }
            return str;
        }

        /// <summary>
        /// Mã hóa chuối đầu vào
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Encrypt(string input)
        {
            string str = string.Empty;
            try
            {
                if (input == null || input.Length <= 0)
                    throw new ArgumentNullException("input empty");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");
                byte[] encrypted;

                byte[] buffer = Encoding.Unicode.GetBytes(input);
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.Zeros;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(buffer, 0, buffer.Length);
                            csEncrypt.FlushFinalBlock();

                            encrypted = new byte[msEncrypt.Length];
                            msEncrypt.Position = 0;
                            msEncrypt.Read(encrypted, 0, encrypted.Length);
                        }
                    }
                }
                str= Convert.ToBase64String(encrypted);
            }
            catch
            {

            }
            return str;
        }
    }
}
