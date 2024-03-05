using GeekShopping.Email.Domain.Entities;
using GeekShopping.Email.Domain.Interfaces.Repository;
using GeekShopping.Email.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Infra.Data.Repository
{
    public class EmailLogRepository : IEmailLogRepository
    {
        private readonly DbContextOptions<MySqlContext> _context;

        public EmailLogRepository(DbContextOptions<MySqlContext> context)
        {
            _context = context;
        }

        public async Task<bool> Save(EmailLog obj)
        {
            await using var _db = new MySqlContext(_context);
            _db.EmailLogs.Add(obj);
            await _db.SaveChangesAsync();

            return true;
        }

        //public async Task<bool> PaymentStatusUpdate(long orderHeaderId, bool status)
        //{
        //    await using var _db = new MySqlContext(_context);

        //    var header = await _db.OrderHeaders.FirstOrDefaultAsync(o => o.Id == orderHeaderId);

        //    if (header != null)
        //    {
        //        header.PaymentStatus = status;
        //        await _db.SaveChangesAsync();
        //    };

        //    return true;
        //}
    }
}
