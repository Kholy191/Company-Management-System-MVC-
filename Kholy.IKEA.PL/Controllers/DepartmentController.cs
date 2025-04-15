using Kholy.IKEA.BLL.Models.Departments;
using Kholy.IKEA.BLL.Services.Departments;
using Kholy.IKEA.PL.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Kholy.IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentServices _departmentServices;
        public DepartmentController(ILogger<DepartmentController> logger, [FromServices] IDepartmentServices departmentService)
        {
            _departmentServices = departmentService;
            _logger = logger;
        }

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetDepartments();
            return View(departments.Select(D => new DepartmentViewModel
            { Id = D.ID, Name = D.Name, Code = D.Code, CreationDate = D.CreationDate }));
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id == null)
            {
                return BadRequest(); //400
            }

            var department = _departmentServices.GetDepartmentDetails((int)id);

            if (department == null)
            {
                return NotFound(); //404
            }

            return View(ViewName, new DepartmentDetailsView
            {
                Id = department.ID,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate,
                LastModifiedOn = department.LastModifiedOn,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                CreatedOn = department.CreatedOn
            });
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentCreateViewModel department)
        {
            if (!ModelState.IsValid) //Server Side Validation
            {
                return View(department);
            }

            var Message = string.Empty;
            try
            {
                var created = _departmentServices.CreateDepartment(new CreateDepartmentDTO
                {
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    CreationDate = department.CreationDate
                }) > 0;
                if (created)
                {
                    Message = "Department Created Successfully";
                }
                else
                {
                    Message = "Department didn't been Created Succesfully";
                }
            }
            catch (Exception ex)
            {
                //Log Exception
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                //Set Message
                Message = "Department didn't been Created Succesfully";
            }
            TempData["Message"] = Message;
            return RedirectToAction(nameof(Index));

        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest(); //400
            }
            var department = _departmentServices.GetDepartmentDetails((int)id);
            if (department == null)
            {
                return NotFound(); //404
            }
            TempData["Id"] = id;
            return View(new UpdateDepartmentViewModel
            {
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description,
                Id = department.ID,
                Name = department.Name,
            });
        }

        [HttpPost]
        public IActionResult Edit(int Id, UpdateDepartmentViewModel department)
        {
            if (!ModelState.IsValid) //Server Side Validation
            {
                return View(department);
            }
            if (department == null)
            {
                return BadRequest(); //400
            }
            if (TempData["Id"] as int? != Id)
            {
                return BadRequest(); //400
            }
            var Message = string.Empty;
            try
            {
                var updated = _departmentServices.UpdateDepartment(new UpdateDepartmentDTO
                {
                    ID = Id,
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    CreationDate = department.CreationDate
                }) > 0;
                if (updated)
                {
                    Message = "Updated Succesfully";
                }
                else
                {
                    Message = "Department didn't been Updated Succesfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                Message = "Department didn't been Updated Succesfully";
            }
            TempData["Message"] = Message;
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Details), new { Id = id, ViewName = "Delete" });
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest(); //400
            }
            var Message = string.Empty;
            try
            {
                var deleted = _departmentServices.DeleteDepartment((int)id);
                if (deleted)
                {
                    Message = "Deleted Succesfully";
                }
                else
                {
                    Message = "Department didn't been Deleted Succesfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                Message = "Department didn't been Deleted Succesfully";
            }
            TempData["Message"] = Message;
            return RedirectToAction(nameof(Index));


        }
        #endregion
    }
}
