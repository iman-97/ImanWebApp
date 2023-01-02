using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.Categories;

//[BindProperties] if we have more than 1 property to bind we can use this
public class CreateModel : PageModel
{
    [BindProperty]
    public Category Category { get; set; }

    private readonly IUnitOfWork _unitOfWork;

    public CreateModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //Without BindProperty attribute

    //public async Task<IActionResult> OnPost(Category category)
    //{
    //    await _dbContext.Category.AddAsync(category);
    //    await _dbContext.SaveChangesAsync();
    //    return RedirectToPage("Index");
    //}

    //With BindProperty attribute

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
            ModelState.AddModelError("Category.Name", "The Display Order cannot exacly match the Name");

        if (ModelState.IsValid == false)
            return Page();

        _unitOfWork.Category.Add(Category);
        _unitOfWork.Save();
        TempData["success"] = "Category created successfully";
        return RedirectToPage("Index");
    }

}
