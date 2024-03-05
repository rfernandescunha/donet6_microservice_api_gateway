namespace GeekShopping.Email.Domain.Dto.Messages
{
    public class PaymentUpdateResultMsgDto
    {
        public long OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
