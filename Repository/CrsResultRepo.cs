using WebApplication1.Models;
using WebApplication1.Repository.IRepository;
using WebApplication1.ViewModels;

namespace WebApplication1.Repository
{
    public class CrsResultRepo : ICrsResultRepo
    {
        AppDbContext Context;
        public CrsResultRepo(AppDbContext context)
        {
            Context = context;
        }

        public List<CrsResultViewModel> DisplayCrsResult(string phoneNumber)
        {
            var result = (from s in Context.Students
                          join cr in Context.CrsResult on s.Id equals cr.Student_id
                          join c in Context.Courses on cr.Course_Id equals c.Id
                          where s.PhoneNumber == phoneNumber
                          select new CrsResultViewModel()
                          {
                              StudentName = s.Name,
                              CourseName = c.Name,
                              Departement = c.Department.Name,
                              Degree = cr.Degree,
                              MinDegree = c.MinDegree
                          }).ToList();

            return result;
        }

    }
}
