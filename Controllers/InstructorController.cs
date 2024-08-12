using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private readonly IInstructorRepo instructorRepo;
        private readonly IDepartmentRepo departmentRepo;
        private readonly ICourseRepo courseRepo;

        public InstructorController(IInstructorRepo instRepo , IDepartmentRepo deptRepo ,ICourseRepo corsrepo)
        {
            instructorRepo = instRepo;
            departmentRepo = deptRepo;
            courseRepo = corsrepo;
        }
        
        public IActionResult Index() =>
         View(instructorRepo.GetAllWithDepartments()); //return list of instructors

        public IActionResult Add()
        {
            ViewData["departments"] = departmentRepo.GetAll();
            ViewData["courses"] =courseRepo.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
               instructorRepo.Add(instructor);
                return RedirectToAction("index");
            }
            ViewData["departments"] =departmentRepo.GetAll();
            ViewData["courses"] = courseRepo.GetAll();
            return View("Add",instructor);
        }

        public IActionResult Edit(int id)
        {
            var instructor = instructorRepo.GetById(id);
            ViewData["departments"] = departmentRepo.GetAll();
            return View(instructor);
        }
        
        [HttpPost]
        public IActionResult SaveEdit(int id ,Instructor newInst) 
        {
            if(ModelState.IsValid)
            {
                instructorRepo.Edit(newInst ,id);
               return RedirectToAction("index");
            }
            ViewData["departments"] = departmentRepo.GetAll();
            return View("Edit" ,newInst); 
        }

        public IActionResult Delete(int id)
        {
            instructorRepo.Delete(id);
            return RedirectToAction("index");
        }

        public IActionResult CheckSalary(int salary)
        {
            if(salary > 2000)
            {
                return Json(true);
            }
            return Json(false);
        }
     
    }
}


