using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library
{
    public static class CacheManager
    {
        private static Dictionary<string, object> dicData = new Dictionary<string, object>();

        public static T Get<T>(string key)
        {
            if (dicData.ContainsKey(key))
            {
                return (T)dicData[key];
            }
            return default(T);
        }

        public static void Set(string key, object data)
        {
            if (!dicData.ContainsKey(key))
            {
                dicData.Add(key, data);
            }
            else
            {
                dicData[key] = data;
            }
        }
    }
}
