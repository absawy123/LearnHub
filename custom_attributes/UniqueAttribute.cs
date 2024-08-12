using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.custom_attributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            AppDbContext context = new();
            Instructor inst = context.Instructors.FirstOrDefault(x => x.Name == value.ToString());
            if (inst == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name is already found");

        }
    }
}
