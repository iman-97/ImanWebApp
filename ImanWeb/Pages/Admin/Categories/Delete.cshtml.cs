using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.Categories;

public class DeleteModel : PageModel
{
    [BindProperty]
    public Category Category { get; set; }

    private readonly IUnitOfWork _unitOfWork;

    public DeleteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet(int id)
    {
        Category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);

        if (categoryFromDb == null)
            return Page();

        _unitOfWork.Category.Remove(categoryFromDb);
        _unitOfWork.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToPage("Index");
    }

}
