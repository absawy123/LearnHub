using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class DepartmentRepo :IDepartmentRepo
    {
        AppDbContext Context;
        public DepartmentRepo(AppDbContext context)
        {
            Context = context;
        }
        public List<Department> GetAll() => Context.Departments.ToList();
        
    }
}
