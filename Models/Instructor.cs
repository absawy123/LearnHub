using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Name should be more than 3 characters")]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Image { get; set; }
        [MaxLength(6)]
        //[Range(2000, 40000, ErrorMessage = "Salary should be between 2000 and 40000")]
        [Remote("CheckSalary","Instructor",ErrorMessage ="Salary should be more than 2000")]
        public string Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Course")]
        public int Course_Id { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set;}
        public virtual Course? Course { get; set; }
        public virtual Department? Department { get; set; }
        
    }
}





