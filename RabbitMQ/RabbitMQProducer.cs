using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace OrderApi.RabbitMQ
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
           // creating a connection to the RabbitMQ Server in the SendMessage method
           var factory = new ConnectionFactory { HostName = "localhost" }; // rabbitMq server will be running local
            var connection = factory.CreateConnection();// creating a connection to the server.
            using var channel = connection.CreateModel(); // channel allow us to interact with the RabbitMQ APIs.
            channel.QueueDeclare("orders"); // this will create q queue on the server with the name of orders.

            // sending a message to this newly created queue
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange:"",routingKey:"orders",body:body);

        }
    }
}
