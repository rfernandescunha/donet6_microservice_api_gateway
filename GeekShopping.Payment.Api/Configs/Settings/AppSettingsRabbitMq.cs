namespace GeekShopping.Payment.Api.Configs.Settings
{
    public class AppSettingsRabbitMq
    {
        public string _hostName { get; set; }
        public string _password { get; set; }
        public string _userName { get; set; }

        public string _queueOrderPaymentProcessResult { get; set; }
        public string _exchangeNamePaymentUpdate { get; set; }
        public string _queueNamePaymentEmailUpdate { get; set; }
        public string _routingKeyPaymentEmailUpdate { get; set; }
        public string _queueNamePaymentOrderUpdate { get; set; }
        public string _routingKeyPaymentOrderUpdate { get; set; }
        public int _executeConsumerTimer { get; set; }
    }
}
