namespace GeekShopping.Payment.Api.Domain.Entities
{
    public class MessageQueue
    {
        public string queueName { get; set; }
        public string routingKey { get; set; }
    }
}
