using Kholy.IKEA.DAL.Contracts.Departments;
using Kholy.IKEA.DAL.Entites.Department;
using Kholy.IKEA.DAL.Persistence.Data;
using Kholy.IKEA.DAL.Persistence.Repositories._Generic;

namespace Kholy.IKEA.DAL.Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department, int> , IDepartmentRepositry
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

