using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Common.Enums;

namespace Kholy.IKEA.BLL.Models.Departments
{
    public record  EmployeeDto
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public string gender { get; set; }
        public string EmployeeType { get; set; }
        public int? DepartmentId { get; set; }
    }
}
