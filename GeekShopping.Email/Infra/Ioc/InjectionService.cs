using GeekShopping.Email.Domain.Interfaces.IServices;
using GeekShopping.Email.Domain.Interfaces.IServices.Messages.Send;
using GeekShopping.Email.Domain.Services;
using GeekShopping.Email.Domain.Services.Messages.Consumer;
using GeekShopping.Email.Domain.Services.Messages.Send;

namespace GeekShopping.Email.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(IRabbitMqSenderMsgServices<>), typeof(RabbitMqSenderServices<>));

            serviceCollection.AddSingleton<IEmailLogServices, EmailLogServices>();
            serviceCollection.AddSingleton<IPaymentSendMsgServices, PaymentSendMsgServices>();

            serviceCollection.AddHostedService<PaymentConsumerMsgServices>();
        }
    }
}