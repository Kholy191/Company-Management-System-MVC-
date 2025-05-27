using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Common.Enums;

namespace Kholy.IKEA.BLL.Models.Departments
{
    public record UpdateEmployeeDTO
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public required string Name { get; set; }

        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
        public int? Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public string? Address { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmpType EmployeeType { get; set; }
        public int? DepartmentId { get; set; }
        public string? Image { get; set; }
    }
}
