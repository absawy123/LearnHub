using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        AppDbContext Context;
        public CourseRepo(AppDbContext context)
        {
            Context = context;
        }

        public List<Course> GetAll() => Context.Courses.ToList();
    }
}
