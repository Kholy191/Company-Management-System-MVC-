using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Contracts.Departments;
using Kholy.IKEA.DAL.Entites.Department;
using Kholy.IKEA.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Kholy.IKEA.DAL.Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepositry
    {
        private ApplicationDbContext _DbContext;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public Department? Get(int id)
        {
            var Department = _DbContext.departments.Find(id);

            //var Department = _DbContext.departments.Local.FirstOrDefault(D => D.ID == id);
            //if (Department == null)
            //{
            //    Department = _DbContext.departments.Local.FirstOrDefault(D => D.ID == id);
            //}
            return Department;
        }

        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (!withTracking)
            {
                return _DbContext.departments.AsNoTracking();
            }
            return _DbContext.departments.AsTracking();
        }

        public void Add(Department department)
        {
            _DbContext.departments.Add(department);
        }

        public void Delete(int id)
        {
            var _department = _DbContext.departments.Find(id);
            if (_department != null)
            {
                _DbContext.departments.Remove(_department);
            }
        }


        public void Update(Department department)
        {

            var Existing = _DbContext.departments.AsTracking().FirstOrDefault(D => D.ID == department.ID);
            if (!(Existing == null))
            {
                Existing.Name = department.Name;
                Existing.Code = department.Code;
                Existing.Description = department.Description;
            }
        }
    }
}
