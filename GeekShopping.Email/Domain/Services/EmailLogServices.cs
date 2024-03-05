using AutoMapper;
using GeekShopping.Email.Domain.Dto.Messages;
using GeekShopping.Email.Domain.Entities;
using GeekShopping.Email.Domain.Interfaces.IServices;
using GeekShopping.Email.Infra.Data.Repository;

namespace GeekShopping.Email.Domain.Services
{
    public class EmailLogServices : IEmailLogServices
    {
        private readonly EmailLogRepository _emailRepository;

        public EmailLogServices(EmailLogRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
        }

        public async Task<bool> LogEmail(PaymentUpdateResultMsgDto dto)
        {
            try
            {
                var email = new EmailLog()
                {
                    Email = dto.Email,
                    SendDate = DateTime.Now,
                    Log = $"Order - {dto.OrderId} has been created successfully!"
                };

                var result = await _emailRepository.Save(email);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
