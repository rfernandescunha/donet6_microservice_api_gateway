using GeekShopping.Email.Domain.Dto.Messages;

namespace GeekShopping.Email.Domain.Interfaces.IServices.Messages.Send
{
    public interface IPaymentSendMsgServices : IRabbitMqSenderMsgServices<PaymentMsgDto>
    {
    }
}
