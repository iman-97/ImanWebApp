using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes;

public class EditModel : PageModel
{
    [BindProperty]
    public FoodType FoodType { get; set; }

    private readonly IUnitOfWork _unitOfWork;

    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet(int id)
    {
        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _unitOfWork.FoodType.Update(FoodType);
        _unitOfWork.Save();
        TempData["success"] = "FoodType updated successfully";
        return RedirectToPage("Index");
    }

}
