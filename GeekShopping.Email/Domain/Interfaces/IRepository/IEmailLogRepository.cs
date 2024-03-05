using GeekShopping.Email.Domain.Entities;
using System.Threading.Tasks;

namespace GeekShopping.Email.Domain.Interfaces.Repository
{
    public interface IEmailLogRepository
    {
        Task<bool> Save(EmailLog obj);
    }
}
