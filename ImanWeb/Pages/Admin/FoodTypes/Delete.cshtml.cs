using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes;

public class DeleteModel : PageModel
{
    [BindProperty]
    public FoodType FoodType { get; set; }

    private readonly IUnitOfWork _unitOfWork;

    public DeleteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet(int id)
    {
        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        var foodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);

        if (foodTypeFromDb == null)
            return Page();

        _unitOfWork.FoodType.Remove(foodTypeFromDb);
        _unitOfWork.Save();
        TempData["success"] = "FoodType deleted successfully";
        return RedirectToPage("Index");
    }

}
