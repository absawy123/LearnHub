using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class LoginUserViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}
