using Kholy.IKEA.DAL.Common.Enums;

namespace Kholy.IKEA.PL.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Salary { get; set; }
        public required bool IsActive { get; set; }
        public required string EmployeeType { get; set; }

    }
}
