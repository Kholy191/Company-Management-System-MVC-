using Kholy.IKEA.DAL.Contracts.Employees;
using Kholy.IKEA.DAL.Entites.Employee;
using Kholy.IKEA.DAL.Persistence.Data;
using Kholy.IKEA.DAL.Persistence.Repositories._Generic;

namespace Kholy.IKEA.DAL.Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, int> , IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
