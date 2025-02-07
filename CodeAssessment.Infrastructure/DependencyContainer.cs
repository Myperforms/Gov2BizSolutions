using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Infrastructure.IRepositories;
using CodeAssessment.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CodeAssessment.Infrastructure
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
