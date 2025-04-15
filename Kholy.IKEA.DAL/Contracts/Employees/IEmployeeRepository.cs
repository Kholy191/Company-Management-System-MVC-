using Kholy.IKEA.DAL.Entites.Employee;
using Kholy.IKEA.DAL.Persistence.Repositories._Generic;

namespace Kholy.IKEA.DAL.Contracts.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee, int>
    {
    }
}
