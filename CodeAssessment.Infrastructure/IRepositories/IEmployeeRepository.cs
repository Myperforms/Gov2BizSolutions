using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Infrastructure.Entities;

namespace CodeAssessment.Infrastructure.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public List<Employee> GetAllEmployees();

        public bool DeleteEmployee(int id);
    }
}
