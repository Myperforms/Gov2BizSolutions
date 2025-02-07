using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Infrastructure.Context;
using CodeAssessment.Infrastructure.Entities;
using CodeAssessment.Infrastructure.IRepositories;

namespace CodeAssessment.Infrastructure.Repositories
{
    public class AdminUserRepository : GenericRepository<AdminUser>, IAdminUserRepository
    {
        private readonly CodeAssessmentDBContext _dbContext;

        public AdminUserRepository(CodeAssessmentDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AdminUser> GetAllUser(string emailAddress)
        {
            return this._dbContext.AdminUsers.Where(x => x.EmailAddress.ToLower().Contains(emailAddress.ToLower())).ToList();
        }
    }
}
