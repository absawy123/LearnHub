using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RegistureUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; } 

        public string Address { get; set; }
    }
}
