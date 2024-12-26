using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace CShop.EventHandle
{
    public class EventConsumer
    {
        public string ReceiveMessage()
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
                var consumer = new EventingBasicConsumer(model);
                var message = "";
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                };
                model.BasicConsume(queue: "demoqueue",
                                 autoAck: true,
                                 consumer: consumer);
                return message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }
    }
}
