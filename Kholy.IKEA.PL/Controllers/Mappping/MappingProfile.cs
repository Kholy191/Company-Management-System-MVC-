using AutoMapper;
using Kholy.IKEA.BLL.Models.Departments;
using Kholy.IKEA.PL.ViewModels.Department;

namespace Kholy.IKEA.PL.Controllers.Mappping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateDepartmentDTO, UpdateDepartmentViewModel>(); // No Meaning for using it now (so just trying it)
        }
    }
}
