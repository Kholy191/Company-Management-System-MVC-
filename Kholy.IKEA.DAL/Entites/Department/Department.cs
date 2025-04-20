using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Common.Entites;

namespace Kholy.IKEA.DAL.Entites.Department
{
    public class Department : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
        public virtual ICollection<Employee.Employee> Employees {  get; set; } = new HashSet<Employee.Employee>();
    }
}
