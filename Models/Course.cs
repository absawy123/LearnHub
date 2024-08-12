using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string MinDegree { get; set; }

        public List<Instructor> Instructors { get; set; }
        public Department Department { get; set; }
        public List<CrsResult> CrsResults { get; set; }

    }

}
