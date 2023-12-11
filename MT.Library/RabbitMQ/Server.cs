using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library.RabbitMQ
{
    public class Server
    {
        public static string HostName { get; set; }

        public static string VirtualHost { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }
        public static ConnectionFactory GetServerQueue()
        {
            string hostName = HostName;
            string virtualHost = VirtualHost;
            string userName = UserName;
            string password = Password;
            return new ConnectionFactory()
            {
                HostName = hostName,
                UserName = userName,
                Password = password,
                VirtualHost = virtualHost
            };
        }
    }
}
