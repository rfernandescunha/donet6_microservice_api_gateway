using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Order.Api.Domain.Dto
{
    public class OrderDetailDto
    {
        public long Id { get; set; }
        public long OrderHeaderId { get; set; }

        public virtual OrderHeaderDto OrderHeader { get; set; }

        public long ProductId { get; set; }

        public int Count { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
