using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Manager { get; set; }
        
        public List<Instructor> Instructors { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Traines { get; set; }

    }
}
