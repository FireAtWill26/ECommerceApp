using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMqHelper
{
    public class MessageQueue
    {
        private readonly ConnectionFactory connectionFactory;
        public MessageQueue(string url, string providerName)
        {
            connectionFactory = new ConnectionFactory();
            connectionFactory.Uri = new Uri(url);
            connectionFactory.ClientProvidedName = providerName;
        }

        public async Task AddMessageToQueue(string message, string exchangeName, string queueName, string routingKey)
        {
            IConnection con = await connectionFactory.CreateConnectionAsync();
            var channel = await con.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName, false, false, false);
            await channel.QueueBindAsync(queueName, exchangeName, routingKey);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchangeName, routingKey, messageBodyBytes);
            await channel.CloseAsync();
            await con.CloseAsync();
            channel.Dispose();
            con.Dispose();
        }


        public async Task<string> ReadMessageFromQueue(string exchangeName, string queueName, string routingKey)
        {
            IConnection con = await connectionFactory.CreateConnectionAsync();
            var channel = await con.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName, false, false, false);
            await channel.QueueBindAsync(queueName, exchangeName, routingKey);
            //await channel.BasicQosAsync(0,1,false);
            //var consumer = new AsyncEventingBasicConsumer(channel);
            var result = await channel.BasicGetAsync(queueName, true);

            await channel.CloseAsync();
            await con.CloseAsync();
            channel.Dispose();
            con.Dispose();
            if (result != null)
            {
                return Encoding.UTF8.GetString(result.Body.ToArray());
            }
            return "no Message";
        }
    }
}
