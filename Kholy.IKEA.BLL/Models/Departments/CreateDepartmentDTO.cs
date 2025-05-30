﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kholy.IKEA.BLL.Models.Departments
{
    public record CreateDepartmentDTO
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }

        
    }
}
