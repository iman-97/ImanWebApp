using ImanWeb.Data;
using ImanWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Categories;

public class EditModel : PageModel
{
    [BindProperty]
    public Category Category { get; set; }

    private readonly ApplicationDbContext _dbContext;

    public EditModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet(int id)
    {
        Category = _dbContext.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
            ModelState.AddModelError("Category.Name", "The Display Order cannot exacly match the Name");

        if (ModelState.IsValid == false)
            return Page();

        _dbContext.Update(Category);
        await _dbContext.SaveChangesAsync();
        TempData["success"] = "Category updated successfully";
        return RedirectToPage("Index");
    }

}
