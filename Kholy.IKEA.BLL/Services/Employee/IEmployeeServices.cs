using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.BLL.Models.Departments;

namespace Kholy.IKEA.BLL.Services.Employee
{
    public interface IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetEmployees();
        public EmployeeDetailsDTO? GetEmployeeDetails(int id);
        int CreateEmployee(CreateEmployeeDTO employee);
        int UpdateEmployee(UpdateEmployeeDTO employee);
        bool DeleteEmployee(int id);
    }
}
