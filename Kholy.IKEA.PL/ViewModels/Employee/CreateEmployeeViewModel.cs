namespace Kholy.IKEA.PL.ViewModels.Employee
{
    public class CreateEmployeeViewModel
    {
        public required string Name { get; set; }
        public int? Age { get; set; }
        public required decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public required bool IsActive { get; set; }
        public DateOnly HiringDate { get; set; }
        public required string gender { get; set; }
        public required string EmployeeType { get; set; }
    }
}
