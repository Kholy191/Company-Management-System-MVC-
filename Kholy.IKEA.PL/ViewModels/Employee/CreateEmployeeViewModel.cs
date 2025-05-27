using System.ComponentModel.DataAnnotations;

namespace Kholy.IKEA.PL.ViewModels.Employee
{
    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage = "Code is required ya Hamada")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public required string Name { get; set; }
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
        public int? Age { get; set; }
        public required decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        [Display(Name = "Is Active")]
        public required bool IsActive { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public required string gender { get; set; }
        public required string EmployeeType { get; set; }
        public int? DepartmentId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
