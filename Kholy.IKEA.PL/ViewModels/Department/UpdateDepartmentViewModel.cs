using System.ComponentModel.DataAnnotations;

namespace Kholy.IKEA.PL.ViewModels.Department
{
    public class UpdateDepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        public required string Code { get; set; }
        [Display(Name = "Creation Date")]
        public required DateOnly CreationDate { get; set; }
        public string? Description { get; set; }
    }
}
