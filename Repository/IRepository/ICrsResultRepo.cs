using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repository.IRepository
{
    public interface ICrsResultRepo
    {
        List<CrsResultViewModel> DisplayCrsResult(string phoneNumber);
    }
}
