using System;
using System.Runtime.Caching;
namespace MT.Library
{
    /// <summary>   
    /// Chú ý: Bạn nên nhớ là MemoryCache sẽ được xóa mỗi khi IIS app pool được làm mới (recycle)
    /// Nếu Web API của bạn :
    /// Không nhận được bất cứ request nào trong vòng hơn 20 phút
    /// Hoặc đặt thời gian mặc định cho IIS làm mới Pool là 1740 phút
    /// Hoặc bạn deploy một bản build mới lên thư mục Web API được triển khai trên IIS
    /// Lưu dữ liệu vào ram
    /// </summary>
    /// Create by: dvthang:22.02.2018
    public class MemoryCacheHelper
    {
        /// <summary>
        /// Get cache value by key
        /// </summary>
        /// <param name="key">Key lưu giá trị vào cache</param>
        /// <returns>Trả về giá trị lưu trong bộ nhớ</returns>
        /// Create by: dvthang:22.02.2018
        public static T Get<T>(string key)
        {
            var data = MemoryCache.Default.Get(key);
            if (data != null)
            {
                return (T)data;
            }
            return default(T);
        }

        /// <summary>
        /// Add a cache object with date expiration
        /// </summary>
        /// <param name="key">Tên key</param>
        /// <param name="value">Giá trị</param>
        /// <param name="absExpiration">Thời gian lưu</param>
        /// <returns>Lưu thành công</returns>
        /// Create by: dvthang:22.02.2018
        public static bool Set(string key,object value, DateTimeOffset absExpiration)
        {
            try
            {
                MemoryCache.Default.Set(key, value, absExpiration);
            }
            catch (Exception ex)
            {
                MT.Library.Log.LogHelper.Error(ex,ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete cache value from key
        /// </summary>
        /// <param name="key">Key cache</param>
        /// Create by: dvthang:22.02.2018
        public static void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }

        /// <summary>
        /// Kiểm tra tồn key trong bộ nhớ
        /// </summary>
        /// <param name="key">Key cache</param>
        /// Create by: dvthang:22.02.2018
        public static bool ContainsKey(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                return true;
            }
            
            return false;
        }
    }
}
