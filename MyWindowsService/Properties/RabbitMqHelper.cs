using System;
using System.Configuration;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MyWindowsService
{
    /// <summary>
    /// rabbitmq 帮助类
    /// </summary>
    public class RabbitMqHelper
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _chanel;
        private string exchangeName = ConfigurationManager.AppSettings["ExchangeName"].ToString();
        private string exchangeType = ConfigurationManager.AppSettings["ExchangeType"];
        private string routingKey = ConfigurationManager.AppSettings["RoutingKey"];
        public RabbitMqHelper()
        {
            _factory = new ConnectionFactory()
            {
                UserName = ConfigurationManager.AppSettings["UserName"],
                Password = ConfigurationManager.AppSettings["Password"],
                HostName = ConfigurationManager.AppSettings["RabbitMqHost"],
                VirtualHost = ConfigurationManager.AppSettings["VirtualHost"]
            };
            _connection = _factory.CreateConnection();
            _chanel = _connection.CreateModel();
        }

        private void Open()
        {

        }
        public void SendMessage(string queueName, string message)
        {
            Open();
            //todo 发送消息
            _chanel.QueueDeclare(queueName, false, false, true, null);
            var bytes = Encoding.UTF8.GetBytes(message);
            _chanel.BasicPublish("", queueName, null, bytes);
            //Console.WriteLine("发送消息");
            //Close();
        }

        public void ReviceMessage(string queueName, Action<string> eventHandel)
        {
            EventingBasicConsumer consumer = new EventingBasicConsumer(_chanel);
            _chanel.ExchangeDeclare(exchangeName, exchangeType);
            _chanel.QueueDeclare(queueName, false, false, false, null);//持久化  排他性 自动删除
            _chanel.QueueBind(queueName, exchangeName, routingKey);//交换机与
            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                eventHandel?.Invoke(message);
                _chanel.BasicAck(ea.DeliveryTag, false);//确认该消息已被消费
            };
            _chanel.BasicConsume(queueName, false, consumer); //启动消费者

            //Console.WriteLine("客户端1已启动");
        }

        public void SendMessage(string message, string someone, Action<string> eventHandel)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            _chanel.BasicPublish(exchangeName, routingKey + someone, null, bytes);
            eventHandel?.Invoke(message);
        }
    }
}