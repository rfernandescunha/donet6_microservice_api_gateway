namespace GeekShopping.Email.Domain.Interfaces.IServices.Messages.Send
{
    public interface IRabbitMqSenderMsgServices<T> where T : class
    {
        void SendMessage(T baseMessage, string queueName);
    }
}
