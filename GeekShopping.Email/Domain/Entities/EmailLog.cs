using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Email.Domain.Entities
{
    [Table("email_log")]
    public class EmailLog : BaseEntity
    {
        [Column("email")]
        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Column("log")]
        public string Log { get; set; }

        [Column("send_date")]
        public DateTime SendDate { get; set; }

    }
}
