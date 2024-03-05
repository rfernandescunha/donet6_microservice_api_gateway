using GeekShopping.Email.Domain.Dto.Messages;

namespace GeekShopping.Email.Domain.Interfaces.IServices
{
    public interface IEmailLogServices
    {
        Task<bool> LogEmail(PaymentUpdateResultMsgDto message);
    }
}
