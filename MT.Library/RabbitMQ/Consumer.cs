using MT.Library.Log;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library.RabbitMQ
{
   public class Consumer
    {
        private ConnectionFactory _connectionFactory;

        private IConnection _connectionQueue;

        private IModel _modelQueue;

        public  void Received(string queueName, Func<string,bool> action, bool ackWhenFinish=false)
        {
            int iRetry = 5;
            while (iRetry > 0)
            {
                try
                {
                    _connectionFactory = Server.GetServerQueue();

                    _connectionQueue = _connectionFactory.CreateConnection();
                    _modelQueue = _connectionQueue.CreateModel();

                    _modelQueue.BasicQos(0, 1, false);
                    _modelQueue.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(_modelQueue);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        if (!ackWhenFinish)
                        {
                            _modelQueue.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                            action.Invoke(message);
                        }
                        else
                        {
                            if (action.Invoke(message))
                            {
                                _modelQueue.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                            }
                        }
                        //todo

                    };
                    _modelQueue.BasicConsume(queue: queueName, false, consumer: consumer);

                    iRetry = 0;
                }
                catch (Exception ex)
                {
                    iRetry--;
                    System.Threading.Thread.Sleep(5000);
                    if (iRetry<=0)
                    {
                        LogHelper.Error(ex, ex.Message);
                    }
                }
            }
            
        }

        public void CloseQueue()
        {
            try
            {
                if (_modelQueue != null)
                {
                    _modelQueue.Close();
                    _modelQueue.Dispose();
                }
                if (_connectionQueue != null)
                {
                    _connectionQueue.Close();
                    _connectionQueue.Dispose();
                }

                if (_connectionFactory != null)
                {
                    _connectionFactory = null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, ex.Message);
            }
        }
    }
}
