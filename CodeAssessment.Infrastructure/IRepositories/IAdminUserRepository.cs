using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Infrastructure.Entities;

namespace CodeAssessment.Infrastructure.IRepositories
{
    public interface IAdminUserRepository : IGenericRepository<AdminUser>
    {
        public List<AdminUser> GetAllUser(string emailAddress);
    }
}
