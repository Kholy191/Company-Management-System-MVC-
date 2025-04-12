using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.DAL.Contracts.Departments;

namespace Kholy.IKEA.DAL.Contracts
{
    public interface IUnitOfWork
    {
        public IDepartmentRepositry DepartmentRepositry { get; set; }
        public void Disponse();
        public int Complete();
    }
}
