using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
    }
}
