using RabbitMQ.Client;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;

namespace CShop.EventHandle
{
    public class EventProducer
    {
        public string SendMessage(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "192.168.1.14",
                UserName = "rootadmin",
                Password = "Abc@123456"
            };
            try
            {
                var connection = factory.CreateConnection();
                var model = connection.CreateModel();
                model.QueueDeclare(queue: "demoqueue", durable: true, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(message);
                model.BasicPublish(exchange: "",
                                 routingKey: "demoqueue",
                                 basicProperties: null,
                                 body: body);
                return message;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
