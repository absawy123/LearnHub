using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICrsResultRepo crsResultRepo;
        public StudentController(ICrsResultRepo crsResultRepo)
        {
            this.crsResultRepo = crsResultRepo;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult DisplayStudentGrades(string phoneNumber)
        {   
            return View(crsResultRepo.DisplayCrsResult(phoneNumber));
        }

    }
}
