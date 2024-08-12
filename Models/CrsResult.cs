using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CrsResult
    {
       
        [ForeignKey("Course")]
        public int Course_Id { get; set; }
        [ForeignKey("Trainee")]
        public int Student_id { get; set; }
        public string Degree { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}



