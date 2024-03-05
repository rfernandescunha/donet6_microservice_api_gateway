using GeekShopping.Payment.Api.Domain.Entities;

namespace GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send
{
    public interface IRabbitMqSenderMsgServices<T> where T : class
    {
        void SendMessageQueue(T baseMessage, string queueName);
        void SendMessageExchangeFanout(T baseMessage, string exchangeName);
        void SendMessageExchangeDirect(T message, string exchangeName, IEnumerable<MessageQueue> queues);
    }
}
