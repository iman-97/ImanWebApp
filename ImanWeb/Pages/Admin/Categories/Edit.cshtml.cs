using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.Categories;

public class EditModel : PageModel
{
    [BindProperty]
    public Category Category { get; set; }

    private readonly IUnitOfWork _unitOfWork;

    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet(int id)
    {
        Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
            ModelState.AddModelError("Category.Name", "The Display Order cannot exacly match the Name");

        if (ModelState.IsValid == false)
            return Page();

        _unitOfWork.Category.Update(Category);
        _unitOfWork.Save();
        TempData["success"] = "Category updated successfully";
        return RedirectToPage("Index");
    }

}
