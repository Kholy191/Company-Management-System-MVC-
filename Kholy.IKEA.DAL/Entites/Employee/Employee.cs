using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Common.Entites;
using Kholy.IKEA.DAL.Common.Enums;

namespace Kholy.IKEA.DAL.Entites.Employee
{
    public class Employee : BaseAuditableEntity<int>
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmpType EmployeeType { get; set; }

    }
}
