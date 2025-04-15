using Kholy.IKEA.DAL.Contracts.Departments;
using Kholy.IKEA.DAL.Contracts.Employees;

namespace Kholy.IKEA.DAL.Contracts
{
    public interface IUnitOfWork
    {
        public IDepartmentRepositry DepartmentRepositry { get; set; }
        public IEmployeeRepository employeeRepository { get; set; }
        public void Disponse();
        public int Complete();
    }
}
