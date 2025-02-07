using System.Security.Claims;
using CodeAssessment.Application.Features.Interfaces;
using CodeAssessment.Application.Features.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace CodeAssessmentProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IAdminUserService _adminUserService;

        public EmployeeController(ILogger<HomeController> logger, IEmployeeService employeeService, IAdminUserService adminUserService)
        {
            this._logger = logger;
            this._employeeService = employeeService;
            this._adminUserService = adminUserService;
        }

        #region Admin User Login
        public IActionResult Login(bool isLogout = false)
        {
            if (isLogout)
            {
                HttpContext.Session.SetString($"AdminType", "");
            }
            var model = new AdminUser();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login([FromBody] AdminUser model)
        {
            var adminusers = this._adminUserService.GetAdminUsers(model.EmailAddress) ?? new List<AdminUser>();

            if (!adminusers.Any())
            {
                return Json(new { IsSuccess = false, ReturnMessage = "User not found" });
            }

            if (adminusers.Any())
            {
                var userDetails = adminusers.FirstOrDefault(x => x.Password == model.Password);
                if (userDetails == null)
                {
                    return Json(new { IsSuccess = false, ReturnMessage = "Incorrect password." });
                }

                var adminType = userDetails.IsGlobalUser ? 1 : 0;

                HttpContext.Session.SetString($"AdminType", adminType.ToString());

            }

            return Json(new { IsSuccess = true, ReturnMessage = "" });
        }

        #endregion Admin User Login


        #region Employee Section
        public IActionResult Index(int id = 0)
        {
            var admintype = HttpContext.Session.GetString($"AdminType").ToString();

            if (string.IsNullOrEmpty(admintype))
            {
                return this.RedirectToAction("Login", "Employee");
            }

            if (admintype == "0")
            {
                return this.RedirectToAction("AllEmployees", "Employee");
            }

            var model = new Employee();

            if (id > 0)
            {
                model = this._employeeService.GetEmployeeDetails(id);
            }

            return View(model);
        }

        public IActionResult AllEmployees()
        {
            var admintype = HttpContext.Session.GetString($"AdminType").ToString();

            if (string.IsNullOrEmpty(admintype))
            {
                return this.RedirectToAction("Login", "Employee");
            }

            int adminType = !string.IsNullOrEmpty(admintype) ? Convert.ToInt32(admintype) : 0;
            ViewBag.IsGlobalUser = adminType == 1 ? true : false;
            var model = this._employeeService.GetAllEmployees();
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateEmployeeDetails([FromBody] Employee model)
        {
            var result = false;
            if (model != null)
            {
                if (model.ID > 0)
                {
                    result = this._employeeService.UpdateEmployeeDetails(model);
                }
                else
                {
                    result = this._employeeService.AddNewEmployee(model);
                }
            }

            return Json(new { IsSuccess = result });
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            return Json(new { IsSuccess = this._employeeService.DeleteEmployee(id) });
        }

        #endregion      
    }
}
