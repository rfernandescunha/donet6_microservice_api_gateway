using GeekShopping.Email.Domain.Interfaces.Repository;
using GeekShopping.Email.Infra.Data.Context;
using GeekShopping.Email.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Infra.Ioc
{
    public static class InjectionRepository
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {


            //Pega a Conexao do arquivo lauch.json
            serviceCollection.AddDbContext<MySqlContext>(options => options.UseMySql(
                                                                                        configuration.GetSection("MySqlConfiguration").GetSection("ConnectionString").Value,
                                                                                        new MySqlServerVersion(new Version(8, 0, 36))));


            //serviceCollection.AddScoped<IEmailLogRepository, EmailLogRepository>();




            var builder = new DbContextOptionsBuilder<MySqlContext>();
            builder.UseMySql(configuration.GetSection("MySqlConfiguration").GetSection("ConnectionString").Value, new MySqlServerVersion(new Version(8, 0, 36)));

            serviceCollection.AddSingleton(new EmailLogRepository(builder.Options));


        }
    }
}
