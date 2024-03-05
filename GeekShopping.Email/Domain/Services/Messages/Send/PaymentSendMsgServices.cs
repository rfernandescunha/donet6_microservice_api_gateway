using GeekShopping.Email.Configs.Settings;
using GeekShopping.Email.Domain.Dto.Messages;
using GeekShopping.Email.Domain.Interfaces.IServices.Messages.Send;
using Microsoft.Extensions.Options;

namespace GeekShopping.Email.Domain.Services.Messages.Send
{
    public class PaymentSendMsgServices : RabbitMqSenderServices<PaymentMsgDto>, IPaymentSendMsgServices
    {
        public PaymentSendMsgServices(IOptions<AppSettingsRabbitMq> serviceSettings) : base(serviceSettings)
        {
        }
    }
}
