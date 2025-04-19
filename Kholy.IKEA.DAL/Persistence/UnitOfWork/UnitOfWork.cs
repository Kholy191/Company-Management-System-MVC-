using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Contracts;
using Kholy.IKEA.DAL.Contracts.Departments;
using Kholy.IKEA.DAL.Contracts.Employees;
using Kholy.IKEA.DAL.Persistence.Data;
using Kholy.IKEA.DAL.Persistence.Repositories;

namespace Kholy.IKEA.DAL.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbcontext;

        public IDepartmentRepositry? DepartmentRepositry { get; set; }
        // Because the unit of work don't have to communicate with DepartmentRepositry 
        // then we made it nullable.
        // need to be injected in the constructor of the unit of work
        
        public IEmployeeRepository employeeRepository { get; set; }

        public UnitOfWork(ApplicationDbContext _dbcontext)
        {
            DepartmentRepositry = new DepartmentRepository((_dbcontext));
            employeeRepository = new EmployeeRepository(_dbcontext);
            dbcontext = _dbcontext;
        }


        public int Complete()
        {
            return dbcontext.SaveChanges();
        }

        public void Disponse()
        {
            dbcontext.Dispose();
        }
    }
}
