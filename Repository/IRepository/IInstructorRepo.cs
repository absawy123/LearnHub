using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IInstructorRepo
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Add(Instructor instructor);
        void Edit(Instructor newInst, int id);
        void Delete(int id);
        List<Instructor> GetAllWithDepartments();


    }
}
