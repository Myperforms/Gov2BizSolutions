using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Infrastructure.Context;
using CodeAssessment.Infrastructure.Entities;
using CodeAssessment.Infrastructure.IRepositories;

namespace CodeAssessment.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        private readonly CodeAssessmentDBContext _dbContext;

        public EmployeeRepository(CodeAssessmentDBContext dbContext)
            : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool DeleteEmployee(int id)
        {
            var employeeDetails = this._dbContext.Employees.FirstOrDefault(x => x.ID == id);
            if (employeeDetails != null)
            {
                this._dbContext.Employees.Remove(employeeDetails);
                this._dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Employee> GetAllEmployees()
        {
            return this._dbContext.Employees.ToList();
        }
    }
}
