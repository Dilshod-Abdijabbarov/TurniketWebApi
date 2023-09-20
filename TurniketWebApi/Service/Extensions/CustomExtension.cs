using TurniketWebApi.Data.IRepositories;
using TurniketWebApi.Data.Repositories;
using TurniketWebApi.Service.IServices;
using TurniketWebApi.Service.Services;

namespace TurniketWebApi.Service.Extensions
{
    public static class CustomExtension
    {
        public static void AddCustomExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(GenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IRegistrationRepositoryAsync, RegistrationRepositoryAsync>();
            services.AddScoped<IRegistrationService, RegistrationService>();         
        }
    }
}
