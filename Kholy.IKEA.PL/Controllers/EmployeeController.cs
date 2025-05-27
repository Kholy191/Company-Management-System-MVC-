using Kholy.IKEA.BLL.Models.Departments;
using Kholy.IKEA.BLL.Services.Departments;
using Kholy.IKEA.BLL.Services.Employee;
using Kholy.IKEA.DAL.Common.Enums;
using Kholy.IKEA.DAL.Entites.Department;
using Kholy.IKEA.DAL.Entites.Employee;
using Kholy.IKEA.PL.ViewModels.Department;
using Kholy.IKEA.PL.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Kholy.IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeServices _Service, ILogger<EmployeeController> logger)
        {
            _employeeServices = _Service;
            _logger = logger;
        }
        [HttpGet]

        #region Index

        public IActionResult Index(string search)
        {
            var _Employees = _employeeServices.GetEmployees(search);
            return View(_Employees.Select(E => new EmployeeViewModel()
            { Name = E.Name, Salary = E.Salary, EmployeeType = E.EmployeeType, IsActive = E.IsActive, Id = E.ID }));
        }

        #endregion

        #region Get Employee Details

        [HttpGet]
        public IActionResult Details([FromServices] IDepartmentServices _departmentServices, int? Id, string ViewName = "Details")
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var employee = _employeeServices.GetEmployeeDetails((int)Id);


            if (employee != null)
            {
                //var Dep = _departmentServices.GetDepartmentDetails(employee.DepartmentId);
                return View(ViewName, new EmployeeDetailsViewModel()
                {
                    Id = employee.ID,
                    Age = employee.Age,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Address = employee.Address,
                    IsActive = employee.IsActive,
                    HiringDate = employee.HiringDate,
                    gender = employee.gender,
                    EmployeeType = employee.EmployeeType,
                    Department = employee.Department?.Name,
                    Image = employee.Image,
                });
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region Create Employee

        [HttpGet]
        public IActionResult Create([FromServices] IDepartmentServices _departmentServices)
        {
            var Departments = _departmentServices.GetDepartments();
            ViewData[index: "Departments"] = Departments;
            return View();
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeViewModel _Employee)
        {
            if (!ModelState.IsValid)
            {
                return View(_Employee);
            }
            var Message = string.Empty;
            try
            {
                EmpType empType;
                Gender Gender;
                if (Enum.TryParse(_Employee.EmployeeType, out empType)) ;
                else
                {
                    empType = EmpType.FullTime;
                }

                if (Enum.TryParse(_Employee.gender, out Gender)) ;
                else
                {
                    Gender = Gender.Male;
                }

                var _employee = new CreateEmployeeDTO()
                {
                    Name = _Employee.Name,
                    Salary = _Employee.Salary,
                    Email = _Employee.Email,
                    Phone = _Employee.Phone,
                    Address = _Employee.Address,
                    IsActive = _Employee.IsActive,
                    Age = _Employee.Age,
                    EmployeeType = empType,
                    gender = Gender,
                    HiringDate = _Employee.HiringDate,
                    DepartmentId = _Employee.DepartmentId,
                    Image = _Employee.Image,
                };

                var result = _employeeServices.CreateEmployee(_employee);

                if (result > 0)
                {
                    Message = "Employee Created Successfully";
                }
                else
                {
                    Message = "Failed to Create Employee";
                }
            }
            catch (Exception ex)
            {
                Message = "Failed to Create Employee";
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
            }
            TempData["Message"] = Message;
            return RedirectToAction("Index");
        }

        #endregion

        #region Update Employee

        [HttpGet]
        public IActionResult Edit(int? id,[FromServices] IDepartmentServices _departmentServices)
        {
            if (id == null)
            {
                return BadRequest(); //400
            }
            var _employee = _employeeServices.GetEmployeeDetails((int)id);
            if (_employee == null)
            {
                return NotFound(); //404
            }
            var Departments = _departmentServices.GetDepartments();
            ViewData["Departments"] = Departments;
            TempData["Id"] = id;
            TempData["Image"] = _employee.Image;
            return View(new EmployeeUpdateViewModel()
            {
                Id = _employee.ID,
                Name = _employee.Name,
                Salary = _employee.Salary,
                Email = _employee.Email,
                Phone = _employee.Phone,
                Address = _employee.Address,
                IsActive = _employee.IsActive,
                Age = _employee.Age,
                gender = _employee.gender,
                EmployeeType = (EmpType)Enum.Parse(typeof(EmpType), _employee.EmployeeType),
                HiringDate = _employee.HiringDate,
                DepartmentId = _employee.Department?.ID,
                Image = _employee.Image,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, EmployeeUpdateViewModel _Employee)
        {
            if (!ModelState.IsValid)
            {
                return View(_Employee);
            }

            if (TempData["Id"] as int? != Id)
            {
                return BadRequest();
            }

            var Message = string.Empty;
            try
            {
                EmpType empType;
                Gender Gender;
                //if (Enum.TryParse(_Employee.EmployeeType, out empType));
                //else
                //{
                //    throw new ArgumentException("Invalid Employee Type");
                //}

                if (Enum.TryParse(_Employee.gender, out Gender)) ;
                else
                {
                    Gender = Gender.Male;
                }

                _employeeServices.UpdateEmployee(new UpdateEmployeeDTO()
                {
                    ID = Id,
                    Name = _Employee.Name,
                    Salary = _Employee.Salary,
                    Email = _Employee.Email,
                    Phone = _Employee.Phone,
                    Address = _Employee.Address,
                    IsActive = _Employee.IsActive,
                    Age = _Employee.Age,
                    EmployeeType = _Employee.EmployeeType,
                    gender = Gender,
                    HiringDate = _Employee.HiringDate,
                    DepartmentId = _Employee.DepartmentId,
                    Image = TempData["Image"] as string
                });
                Message = "Employee Updated Successfully";
            }
            catch (Exception ex)
            {
                Message = "Failed to Delete Employee";
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
            }
            TempData["Message"] = Message;
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete Employee

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            return RedirectToAction(nameof(Details), new { Id = Id, ViewName = "Delete" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var Message = string.Empty;
            try
            {
                var result = _employeeServices.DeleteEmployee((int)Id);
                Message = result is true ? "Employee Deleted Successfully" : "Failed to Delete Employee";
            }
            catch (Exception ex)
            {
                Message = "Failed to Delete Employee";
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
            }
            TempData["Message"] = Message;
            return RedirectToAction("Index");
        }



        #endregion
    }

}

