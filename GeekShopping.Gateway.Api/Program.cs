using GeekShopping.Gateway.Api.Configs;
using GeekShopping.Gateway.ApiWeb.Configs.Settings;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace GeekShopping.Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration;

            var builder = WebApplication.CreateBuilder(args);

            configuration = builder.Configuration;

            builder.Services.AddOptions();

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(x => x.SerializerOptions.IncludeFields = true);

            builder.Services.Configure<AppSettingsServicesUrl>(configuration.GetSection("ServicesUrl"));

            builder.Services.AddAuthenticationConfig(configuration);


            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();


            builder.Services.AddOcelot();


            var app = builder.Build();


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseOcelot();

            app.Run();
        }
    }
}
