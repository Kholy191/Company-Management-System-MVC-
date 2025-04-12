using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kholy.IKEA.BLL.Models.Departments
{
    public record  DepartmentDto
    {

        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required DateOnly CreationDate { get; set; }
    }
}
