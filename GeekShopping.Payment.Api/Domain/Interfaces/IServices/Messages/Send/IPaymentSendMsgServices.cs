using GeekShopping.Payment.Api.Domain.Dto.Messages;
using GeekShopping.Payment.Api.Domain.Entities;
using System.Security.Cryptography;

namespace GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send
{
    public interface IPaymentSendMsgServices : IRabbitMqSenderMsgServices<PaymentProcessConsumerMsgDto>
    {
        void SendMessageQueuePaymentUpdate(PaymentProcessResultSendMsgDto baseMessage, string queueName);

        //void SendMessageExchangePaymentUpdate(PaymentProcessResultSendMsgDto baseMessage, string exchangeName);

        void SendMessageExchangePaymentUpdate(PaymentProcessResultSendMsgDto baseMessage, string exchangeName, IEnumerable<MessageQueue> queues);
    }
}
