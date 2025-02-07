using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Application.Features.Models;

namespace CodeAssessment.Application.Features.Interfaces
{
    public interface IAdminUserService
    {
        public List<AdminUser> GetAdminUsers(string emailAddress);
    }
}