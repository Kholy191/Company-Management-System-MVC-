using System.ComponentModel.DataAnnotations;

namespace Kholy.IKEA.PL.ViewModels.Department
{
    public class DepartmentViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        [Display(Name = "Creation Date")]
        public required DateOnly CreationDate { get; set; }
    }
}
