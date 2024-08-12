using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class InstructorRepo : IInstructorRepo
    {
        AppDbContext Context;
        public InstructorRepo(AppDbContext context)
        {
            Context = context;
        }
        public List<Instructor> GetAll() => Context.Instructors.ToList();
        public Instructor GetById(int id)
        {
            return Context.Instructors.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Instructor instructor)
        {
            Context.Add(instructor);
            Context.SaveChanges();
        }
        public void Edit(Instructor newInst,int id)
        {
            var oldInst = GetById(id);
            oldInst.Salary = newInst.Salary;
            oldInst.Name = newInst.Name;
            oldInst.Address = newInst.Address;
            oldInst.Dept_Id = newInst.Dept_Id;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Instructor instructor =GetById(id);
            Context.Instructors.Remove(instructor);
            Context.SaveChanges();
        }

        public List<Instructor> GetAllWithDepartments()
        {
         return Context.Instructors.Include(x => x.Department).OrderByDescending(e => e.Id).ToList();
        }
    }
}





