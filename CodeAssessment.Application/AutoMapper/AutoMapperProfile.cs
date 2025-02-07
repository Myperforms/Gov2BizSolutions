using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CodeAssessment.Application.AutoMapper
{
    using CodeAssessment.Application.Features.Models;
    using global::AutoMapper;

    /// <summary>
    /// The profile of auto mapper.
    /// </summary>
    /// <seealso cref="Profile" />
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            this.CreateMap<Employee, CodeAssessment.Infrastructure.Entities.Employee>().ReverseMap();
            this.CreateMap<AdminUser, CodeAssessment.Infrastructure.Entities.AdminUser>().ReverseMap();          
        }

    }
}
