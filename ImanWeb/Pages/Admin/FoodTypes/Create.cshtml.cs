using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes;

public class CreateModel : PageModel
{
    [BindProperty]
    public FoodType FoodType { get; set; }

    private readonly IUnitOfWork _unitOfWork;

    public CreateModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _unitOfWork.FoodType.Add(FoodType);
        _unitOfWork.Save();
        TempData["success"] = "FoodType created successfully";
        return RedirectToPage("Index");
    }

}
