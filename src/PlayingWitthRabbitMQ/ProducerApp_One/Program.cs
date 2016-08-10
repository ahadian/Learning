using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace ProducerApp_One
{
    public class ExchangeDefinition
    {
        public string Name { get; set; }

        public string ExchangeType { get; set; }

        public bool Durable { get; set; }
    }

    public class QueueDefinition
    {
        public string Name { get; set; }

        public bool Durable { get; set; }

        public bool Exclusive { get; set; }

        public bool Autodelete { get; set; }

        public Dictionary<string, object> Arguments { get; set; }
    }

    

    internal class Program
    {
        public static IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "localhost";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";
            return connectionFactory.CreateConnection();
        }
        private static void SetupDurableElements(IModel model)
        {
            model.QueueDeclare("DurableQueue", true, false, false, null);
            model.ExchangeDeclare("DurableExchange", ExchangeType.Topic, true);
            model.QueueBind("DurableQueue", "DurableExchange", "durable");
        }

        private static void SetupInitialTopicQueue(IModel model)
        {
            model.QueueDeclare("queueFromVisualStudio", true, false, false, null);
            model.ExchangeDeclare("exchangeFromVisualStudio", ExchangeType.Topic);
            model.QueueBind("queueFromVisualStudio", "exchangeFromVisualStudio", "superstars");
        }
        private static void SendDurableMessageToDurableQueue(IModel model)
        {
            IBasicProperties basicProperties = model.CreateBasicProperties();
            basicProperties.SetPersistent(true);
            byte[] payload = Encoding.UTF8.GetBytes("This is a persistent message from Visual Studio");
            PublicationAddress address = new PublicationAddress(ExchangeType.Topic, "DurableExchange", "durable");
            model.BasicPublish(address, basicProperties, payload);
        }
        private static void Main(string[] args)
        {

            var factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";
            string exchangeName = "Durable-Exchange";
            string queueName = "Durable-Queue";
            string routingKey = "durable-routing-Key";
            IConnection conn = factory.CreateConnection();// try catch!!!
            var channel = conn.CreateModel();


            channel.QueueDeclare(queueName, true, false, false, null);
            channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true);
            channel.QueueBind(queueName, exchangeName, routingKey);


            for (int i = 0; i < 5; i++)
            {
                var message = string.Format("Message #{0}: {1}", i + 1, Guid.NewGuid());
                var messageBodyBytes = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
                Console.WriteLine();
            }

            channel.Dispose();
            conn.Dispose();
            
        }
    }
}
