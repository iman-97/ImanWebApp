using ImanWebApp.DataAccess.Data;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.Categories;

//[BindProperties] if we have more than 1 property to bind we can use this
public class CreateModel : PageModel
{
    [BindProperty]
    public Category Category { get; set; }

    private readonly ApplicationDbContext _dbContext;

    public CreateModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
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

        await _dbContext.Category.AddAsync(Category);
        await _dbContext.SaveChangesAsync();
        TempData["success"] = "Category created successfully";
        return RedirectToPage("Index");
    }

}
