using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Application.Features.Models;

namespace CodeAssessment.Application.Features.Interfaces
{
    public interface IEmployeeService 
    {
      public  bool AddNewEmployee(Employee employee);

        public List<Employee> GetAllEmployees();

        public bool UpdateEmployeeDetails(Employee employee);

        public bool DeleteEmployee(int id);

        public Employee GetEmployeeDetails(int id);
    }
}
