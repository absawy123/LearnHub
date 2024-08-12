using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Address { get; set; }
        public string Level { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public Department? Department { get; set; }
        public List<CrsResult>? CrsResults { get; set; }



    }
}
