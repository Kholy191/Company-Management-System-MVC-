using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.BLL.Common.Services.Attachments;
using Kholy.IKEA.BLL.Models.Departments;
using Kholy.IKEA.DAL.Common.Enums;
using Kholy.IKEA.DAL.Contracts;
using Kholy.IKEA.DAL.Entites.Department;
using Kholy.IKEA.DAL.Entites.Employee;


namespace Kholy.IKEA.BLL.Services.Employee
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttachmentService attachmentService;
        public EmployeeServices(IUnitOfWork unitofwork , IAttachmentService _attachmentService)
        {
            _unitOfWork = unitofwork;
            attachmentService = _attachmentService;
        }

        public int CreateEmployee(CreateEmployeeDTO employee)
        {
            if (employee == null)
            {
                return 0;
            }

            _unitOfWork.employeeRepository.Add(new DAL.Entites.Employee.Employee()
            {
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                Phone = employee.Phone,
                Address = employee.Address,
                IsActive = employee.IsActive,
                CreatedBy = "Admin",
                LastModifiedBy = "Admin",
                gender = employee.gender,
                EmployeeType = employee.EmployeeType,
                DepartmentID = employee.DepartmentId,
                HiringDate = employee.HiringDate,
                Image = employee.Image != null ? attachmentService.Upload(employee.Image, "Images") : null,
            });
            return _unitOfWork.Complete();
        }

        public bool DeleteEmployee(int Id)
        {
            _unitOfWork.employeeRepository.Delete(Id);
            var deleted = _unitOfWork.Complete() > 0;
            return deleted;
        }

        public IQueryable<EmployeeDto> GetEmployees(string? search)
        {

            var Employees = _unitOfWork.employeeRepository.GetQueryable().Where(D => string.IsNullOrEmpty(search) || (D.Name.Contains(search))).Select(employee => new EmployeeDto
            {
                Name = employee.Name,
                ID = employee.ID,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                IsActive = employee.IsActive,
                EmployeeType = employee.EmployeeType.ToString(),
                gender = employee.gender.ToString(),
                DepartmentId = employee.DepartmentID,
            });
            return Employees;

            //foreach (var employee in Employees)
            //{
            //    yield return new EmployeeDto
            //    {
            //        Name = employee.Name,
            //        ID = employee.ID,
            //        Age = employee.Age,
            //        Salary = employee.Salary,
            //        Email = employee.Email,
            //        IsActive = employee.IsActive,
            //        EmployeeType = employee.EmployeeType.ToString(),
            //        gender = employee.gender.ToString(),
            //    };
            //}
        }

        public EmployeeDetailsDTO? GetEmployeeDetails(int id)
        {
            var employee = _unitOfWork.employeeRepository.Get(id);
            if (employee == null)
            {
                return null;
            }

            return new EmployeeDetailsDTO()
            {
                ID = employee.ID,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                Phone = employee.Phone,
                Address = employee.Address,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                EmployeeType = employee.EmployeeType.ToString(),
                gender = employee.gender.ToString(),
                Department = employee.Department,
                Image = employee.Image,
            };

        }

        public int UpdateEmployee(UpdateEmployeeDTO _employee)
        {
            if (_employee != null)
            {
                var employee = _unitOfWork.employeeRepository.Get(_employee.ID);
                if (employee != null)
                {
                    _unitOfWork.employeeRepository.Update(new DAL.Entites.Employee.Employee()
                    {
                        Salary = _employee.Salary,
                        Name = _employee.Name,
                        Age = _employee.Age,
                        Email = _employee.Email,
                        Phone = _employee.Phone,
                        Address = _employee.Address,
                        IsActive = _employee.IsActive,
                        HiringDate = _employee.HiringDate,
                        gender = _employee.gender,
                        EmployeeType = _employee.EmployeeType,
                        ID = _employee.ID,
                        LastModifiedBy = "Admin",
                        CreatedBy = "Admin",
                        DepartmentID = _employee.DepartmentId,
                        Image = _employee.Image

                    });
                    return _unitOfWork.Complete();
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

    }


}

