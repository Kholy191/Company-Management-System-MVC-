using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Entites.Department;

namespace Kholy.IKEA.DAL.Contracts.Departments
{
    public interface IDepartmentRepositry
    {
        IEnumerable<Department> GetAll(bool withTracking = false); //عشان محتاج تعمل عليها انيموريشن عليها بس
        Department? Get(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
    }
}
