using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CodeAssessment.Application.Features.Interfaces;
using CodeAssessment.Application.Features.Models;
using CodeAssessment.Infrastructure.IRepositories;
using Microsoft.Extensions.Logging;

namespace CodeAssessment.Application.Features.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IMapper mapper, ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
            this._logger = logger;
        }

        public bool AddNewEmployee(Employee employee)
        {
            var result = false;
            try
            {
                var model = this._mapper.Map<Infrastructure.Entities.Employee>(employee);

                if (model != null)
                {
                    model.CreatedDate = DateTime.Now;
                    this._employeeRepository.Insert(model);
                    this._employeeRepository.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Employee Service >> AddNewEmployee" + ex.Message);
                result = false;
            }

            return result;
        }

        public bool DeleteEmployee(int id)
        {
            return this._employeeRepository.DeleteEmployee(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return this._mapper.Map<List<Employee>>(this._employeeRepository.GetAllEmployees());
        }

        public Employee GetEmployeeDetails(int id)
        {
            return this._mapper.Map<Employee>(this._employeeRepository.GetById(id));
        }

        public bool UpdateEmployeeDetails(Employee employee)
        {
            var result = false;
            try
            {
                if (employee.ID > 0)
                {
                    var employeedetails = this._employeeRepository.GetById(employee.ID);

                    if (employeedetails != null)
                    {
                        employeedetails.Name = employee.Name;
                        employeedetails.Department = employee.Department;
                        employeedetails.Salary = employee.Salary;
                        employeedetails.RemoteWorkStatus = employee.RemoteWorkStatus;
                        employeedetails.JobTittle = employee.JobTittle;
                        employeedetails.UpdatedDate = DateTime.Now;
                        this._employeeRepository.Update(employeedetails);
                        this._employeeRepository.SaveChanges();
                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Employee Service >> UpdateEmployeeDetails > " + ex.Message);
                result = false;
            }

            return result;
        }
    }
}
