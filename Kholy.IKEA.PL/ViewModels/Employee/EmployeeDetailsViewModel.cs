using Kholy.IKEA.DAL.Common.Enums;

namespace Kholy.IKEA.PL.ViewModels.Employee
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public DateOnly HiringDate { get; set; }
        public string gender { get; set; }
        public string EmployeeType { get; set; }
    }
}
