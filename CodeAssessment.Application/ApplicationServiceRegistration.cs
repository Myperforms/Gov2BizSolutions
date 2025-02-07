using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Application.Features.Interfaces;
using CodeAssessment.Application.Features.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CodeAssessment.Application
{
    public static class ApplicationServiceRegistration
    {
        
        private static IServiceCollection serviceCollection;

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
            return services;
        }


        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAdminUserService, AdminUserService>();

            serviceCollection = services;
        }
    }
}
