using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FormUI
{
    class RB_AppSettings
    {
        private const string mscConnectionName = "ConnectionString";
        /// <summary>
        /// Lấy ra giá trị của key lưu trong file app
        /// </summary>
        /// <param name="key">Tên key</param>
        /// <returns>Trả về giá trị của key</returns>
        /// Create by: dvthang:28.05.2017
        public static string Get(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Lưu chuỗi connection string
        /// </summary>
        /// <param name="constr">Tên chuỗi connection string</param>
        /// Create by: dvthang:28.05.2017
        public static void SaveConnectionString(string constr)
        {
            Set(mscConnectionName, constr);
        }
        /// <summary>
        /// Lấy chuỗi connection string
        /// </summary>
        /// <param name="constr">Tên chuỗi connection string</param>
        /// Create by: dvthang:28.05.2017
        public static string GetConnectionString()
        {

            return Get(mscConnectionName);
        }

        /// <summary>
        /// Load file config
        /// </summary>
        /// <returns>Trả về file config được tìm thấy</returns>
        /// Create by: dvthang:11.06.2017
        private static XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(GetConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
        /// <summary>
        /// Đọc đường dẫn lưu file app.config
        /// </summary>
        /// <returns>Trả về đường dẫn</returns>
        /// Create by: dvthang:11.06.2017
        private static string GetConfigFilePath()
        {
            string strCurrent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            return strCurrent + "\\App.config";
        }
        public static void Set(string key, string value)
        {
            // load config document for current assembly
            XmlDocument doc = LoadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");

            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));

                if (elem != null)
                {
                    // add value for key
                    elem.SetAttribute("value", value);
                }
                else
                {
                    // key was not found so create the 'add' element 
                    // and set it's key/value attributes 
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save(GetConfigFilePath());
            }
            catch
            {
                throw;
            }
        }
    }
}
