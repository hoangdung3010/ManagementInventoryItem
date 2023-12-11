using MT.Library.Log;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library.RabbitMQ
{
   public class Producer
    {
        public static void SendMessage(string routingKey,string message)
        {
            try
            {
                var factory = Server.GetServerQueue();
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: routingKey,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var property = channel.CreateBasicProperties();
                    property.Persistent = true;
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: routingKey,
                                         basicProperties: property,
                                         body: body);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex,ex.Message);
                
            }
        }
    }
}
