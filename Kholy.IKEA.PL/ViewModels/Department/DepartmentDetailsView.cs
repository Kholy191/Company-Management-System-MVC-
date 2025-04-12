using System.ComponentModel.DataAnnotations;

namespace Kholy.IKEA.PL.ViewModels.Department
{
    public class DepartmentDetailsView
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        [Display(Name = "Creation Date")]
        public required DateOnly CreationDate { get; set; }
        [Display(Name = "Last Modified On")]
        public required DateTime LastModifiedOn { get; set; }
        [Display(Name = "Created By")]
        public required string CreatedBy { get; set; }
        [Display(Name = "Last Modified By")]
        public required string LastModifiedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}
