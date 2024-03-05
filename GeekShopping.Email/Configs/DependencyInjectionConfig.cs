using GeekShopping.Email.Infra.Ioc;

namespace GeekShopping.Email.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            InjectionRepository.Register(services, configuration);
            InjectionService.Register(services);
            InjectionAutoMapper.Register(services);
        }
    }
}
