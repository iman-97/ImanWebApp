using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes;

public class IndexModel : PageModel
{
    public IEnumerable<FoodType> FoodTypes { get; set; }

    private readonly IUnitOfWork _unitOfWork;

    public IndexModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet()
    {
        FoodTypes = _unitOfWork.FoodType.GetAll();
    }

}
