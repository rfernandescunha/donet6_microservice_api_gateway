using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using System;
using GeekShopping.Payment.Api.Configs.Settings;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send;
using GeekShopping.Payment.Api.Domain.Entities;

namespace GeekShopping.Payment.Api.Domain.Services.Messages.Send
{
    public class RabbitMqSenderServices<T> : IRabbitMqSenderMsgServices<T> where T : class
    {
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;

        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMqSenderServices(IOptions<AppSettingsRabbitMq> serviceSettings)
        {
            _serviceSettings = serviceSettings;

            _hostName = _serviceSettings.Value._hostName;
            _password = _serviceSettings.Value._password;
            _userName = _serviceSettings.Value._userName;
        }

        /// <summary>
        /// Send Message Queue
        /// </summary>
        /// <param name="message"></param>
        /// <param name="queueName"></param>
        /// <exception cref="Exception"></exception>
        public void SendMessageQueue(T message, string queueName)
        {
            try
            {
                CreateConnection();

                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);

                    byte[] body = GetMessageAsByteArray(message);

                    channel.BasicPublish(
                                            exchange: "",
                                            routingKey: queueName,
                                            basicProperties: null,
                                            body: body);
                }
            }
            catch (Exception)
            {
                throw new Exception($"erroo send msg {queueName}");
            }

        }

        /// <summary>
        /// Send Message Exchange
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exchangeName"></param>
        /// <exception cref="Exception"></exception>
        public void SendMessageExchangeFanout(T message, string exchangeName)
        {
            try
            {
                CreateConnection();

                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, durable: false);

                    byte[] body = GetMessageAsByteArray(message);

                    channel.BasicPublish(
                                            exchange: exchangeName,
                                            routingKey: string.Empty,
                                            basicProperties: null,
                                            body: body);
                }
            }
            catch (Exception)
            {
                throw new Exception($"erroo send msg {exchangeName}");
            }

        }

        public void SendMessageExchangeDirect(T message, string exchangeName, IEnumerable<MessageQueue> queues)
        {
            try
            {
                CreateConnection();

                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, durable: false);

                    foreach (var queue in queues)
                    {
                        channel.QueueDeclare(queue.queueName, false, false, false, null);
                        channel.QueueBind(queue.queueName, exchangeName, queue.routingKey);

                        byte[] body = GetMessageAsByteArray(message);

                        channel.BasicPublish(
                                                exchange: exchangeName,
                                                routingKey: queue.routingKey,
                                                basicProperties: null,
                                                body: body);
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception($"erroo send msg {exchangeName}");
            }

        }

        private byte[] GetMessageAsByteArray(T message)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }


        private void CreateConnection()
        {
            try
            {
                if (_connection == null)
                {
                    var factory = new ConnectionFactory
                    {
                        HostName = _hostName,
                        Password = _password,
                        UserName = _userName,
                    };

                    _connection = factory.CreateConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
