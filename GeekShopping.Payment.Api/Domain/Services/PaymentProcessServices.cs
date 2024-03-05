using GeekShopping.Payment.Api.Configs.Settings;
using GeekShopping.Payment.Api.Domain.Dto;
using GeekShopping.Payment.Api.Domain.Dto.Messages;
using GeekShopping.Payment.Api.Domain.Entities;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send;
using Microsoft.Extensions.Options;

namespace GeekShopping.Payment.Api.Domain.Services
{
    public class PaymentProcessServices : IPaymentProcessServices
    {
        private readonly IPaymentSendMsgServices _paymentSendMsgServices;
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;

        public PaymentProcessServices(IPaymentSendMsgServices paymentSendMsgServices, IOptions<AppSettingsRabbitMq> serviceSettings)
        {
            _paymentSendMsgServices = paymentSendMsgServices;
            _serviceSettings = serviceSettings;
        }

        public void PaymentProcess(PaymentDto dto)
        {
            var queues = new List<MessageQueue>
            {
                new() {queueName = _serviceSettings.Value._queueNamePaymentEmailUpdate, routingKey = _serviceSettings.Value._routingKeyPaymentEmailUpdate},
                new() {queueName = _serviceSettings.Value._queueNamePaymentOrderUpdate, routingKey = _serviceSettings.Value._routingKeyPaymentOrderUpdate}
            };
            
            _paymentSendMsgServices.SendMessageExchangePaymentUpdate(ProcessMsg(dto), _serviceSettings.Value._exchangeNamePaymentUpdate, queues);
        }

        private PaymentProcessResultSendMsgDto ProcessMsg(PaymentDto vo)
        {
            var paymentUpdate = new PaymentProcessResultSendMsgDto()
            {
                Status = true,
                OrderId = vo.OrderId,
                Email = vo.Email,

            };

            return paymentUpdate;
        }
    }
}
