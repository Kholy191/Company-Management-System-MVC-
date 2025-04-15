using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Entites.Department;
using Kholy.IKEA.DAL.Persistence.Repositories._Generic;

namespace Kholy.IKEA.DAL.Contracts.Departments
{
    public interface IDepartmentRepositry : IGenericRepository<Department, int>
    {
    
    }
}
