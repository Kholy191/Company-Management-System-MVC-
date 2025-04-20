using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kholy.IKEA.BLL.Models.Departments;
using Kholy.IKEA.DAL.Contracts;
using Kholy.IKEA.DAL.Entites.Department;

namespace Kholy.IKEA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentServices
    {
        #region UnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public DepartmentDetailsDTO? GetDepartmentDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var department = _unitOfWork.DepartmentRepositry.Get((int) id);

            if (department == null)
            {
                return null;
            }

            return new DepartmentDetailsDTO
            {
                ID = department.ID,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                LastModifiedOn = department.LastModifiedOn,
                Code = department.Code,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,

            };
        }

        public IEnumerable<DepartmentDto> GetDepartments()
        {
            var departments = _unitOfWork.DepartmentRepositry.GetAll();
            foreach (var item in departments)
            {
                yield return new DepartmentDto
                {
                    ID = item.ID,
                    Name = item.Name,
                    Code = item.Code,
                    CreationDate = item.CreationDate
                };

            }
        }

        public int CreateDepartment(CreateDepartmentDTO department)
        {
            var _department = new Department
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = "",
                LastModifiedBy = "",
            };

            _unitOfWork.DepartmentRepositry.Add(_department);
            return _unitOfWork.Complete();
        }

        public bool DeleteDepartment(int id)
        {
            _unitOfWork.DepartmentRepositry.Delete(id);
            var deleted = _unitOfWork.Complete() > 0;
            return deleted;
        }

        public int UpdateDepartment(UpdateDepartmentDTO department)
        {
            if (department != null)
            {
                var DepartmentToUpdate = _unitOfWork.DepartmentRepositry.Get(department.ID);
                if (DepartmentToUpdate == null)
                {
                    return 0;
                }
                else
                {
                    _unitOfWork.DepartmentRepositry.Update(new Department
                    {
                        ID = department.ID,
                        Name = department.Name,
                        Code = department.Code,
                        Description = department.Description,
                        CreationDate = department.CreationDate,
                        CreatedBy = "",
                        LastModifiedBy = "",
                    });
                    return _unitOfWork.Complete();
                }
            }
            return 0;
        }

        #endregion
    }
}
