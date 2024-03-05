
using GeekShopping.Email.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Infra.Data.Context
{

    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<EmailLog> EmailLogs { get; set; }

    }
}
