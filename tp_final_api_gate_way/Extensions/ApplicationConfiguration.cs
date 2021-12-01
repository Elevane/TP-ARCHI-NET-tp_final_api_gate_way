using System.Reflection;
using tp_final_api_gate_way.ApiServices;

namespace tp_final_api_gate_way.Extensions
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
