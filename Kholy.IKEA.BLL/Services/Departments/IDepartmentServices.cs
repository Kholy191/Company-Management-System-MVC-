using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.BLL.Models.Departments;
using Kholy.IKEA.DAL.Entites.Department;

namespace Kholy.IKEA.BLL.Services.Departments
{
    public interface IDepartmentServices
    {
        public IEnumerable<DepartmentDto> GetDepartments();
        public DepartmentDetailsDTO? GetDepartmentDetails(int id);
        int CreateDepartment(CreateDepartmentDTO department);
        int UpdateDepartment(UpdateDepartmentDTO department);
        bool DeleteDepartment(int id);
    }
}
