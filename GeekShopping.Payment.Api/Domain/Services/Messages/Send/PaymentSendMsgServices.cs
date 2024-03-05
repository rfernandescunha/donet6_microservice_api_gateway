using GeekShopping.Payment.Api.Configs.Settings;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send;
using Microsoft.Extensions.Options;
using GeekShopping.Payment.Api.Domain.Dto.Messages;
using GeekShopping.Payment.Api.Domain.Entities;

namespace GeekShopping.Payment.Api.Domain.Services.Messages.Send
{
    public class PaymentSendMsgServices : RabbitMqSenderServices<PaymentProcessConsumerMsgDto>, IPaymentSendMsgServices
    {
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;

        public PaymentSendMsgServices(IOptions<AppSettingsRabbitMq> serviceSettings) : base(serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }

        public void SendMessageExchangePaymentUpdate(PaymentProcessResultSendMsgDto baseMessage, string exchangeName, IEnumerable<MessageQueue> queues)
        {
            var _senderMsgPaymentUpdate = new RabbitMqSenderServices<PaymentProcessResultSendMsgDto>(_serviceSettings);

            _senderMsgPaymentUpdate.SendMessageExchangeDirect(baseMessage, exchangeName, queues);
        }

        public void SendMessageQueuePaymentUpdate(PaymentProcessResultSendMsgDto baseMessage, string queueName)
        {
            var _senderMsgPaymentUpdate = new RabbitMqSenderServices<PaymentProcessResultSendMsgDto>(_serviceSettings);

            _senderMsgPaymentUpdate.SendMessageQueue(baseMessage, queueName);
        }
    }
}
