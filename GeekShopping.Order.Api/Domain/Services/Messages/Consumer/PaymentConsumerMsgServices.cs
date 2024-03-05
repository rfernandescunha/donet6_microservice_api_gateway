using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using GeekShopping.Order.Api.Domain.Dto.Messages;
using GeekShopping.Order.Api.Domain.Interfaces.IServices;
using GeekShopping.Order.Api.Configs.Settings;

namespace GeekShopping.Order.Api.Domain.Services.Messages.Consumer
{
    public class PaymentConsumerMsgServices : BackgroundService
    {
        private readonly ILogger<CheckoutConsumerMsgServices> _logger;
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;
        private readonly IOrderServices _orderServices;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PaymentConsumerMsgServices(ILogger<CheckoutConsumerMsgServices> logger, IOrderServices orderServices, IOptions<AppSettingsRabbitMq> serviceSettings)
        {
            _serviceSettings = serviceSettings;
            _orderServices = orderServices;
            _logger = logger;

            var factory = new ConnectionFactory
            {
                HostName = _serviceSettings.Value._hostName,
                UserName = _serviceSettings.Value._password,
                Password = _serviceSettings.Value._password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_serviceSettings.Value._exchangeNamePaymentUpdate, ExchangeType.Direct);

            _channel.QueueDeclare(_serviceSettings.Value._queueNamePaymentOrderUpdate, false, false, false, null);

            _channel.QueueBind(_serviceSettings.Value._queueNamePaymentOrderUpdate, _serviceSettings.Value._exchangeNamePaymentUpdate, _serviceSettings.Value._routingKeyPaymentOrderUpdate);

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("await messages...");

            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());

                _logger.LogInformation($"[New message | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " + content);

                var dto = JsonSerializer.Deserialize<PaymentUpdateResultMsgDto>(content);


                _orderServices.PaymentStatusUpdate(dto.OrderId, dto.Status);

                _channel.BasicAck(evt.DeliveryTag, false);
            };

            _channel.BasicConsume(_serviceSettings.Value._queueNamePaymentOrderUpdate, false, consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"PaymentConsumerMsgServices active em: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                await Task.Delay(_serviceSettings.Value._executeConsumerTimer, stoppingToken);
            }
        }

    }
}
