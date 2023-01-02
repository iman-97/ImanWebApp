using ImanWebApp.DataAccess.Data;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.Categories;

public class DeleteModel : PageModel
{
    [BindProperty]
    public Category Category { get; set; }

    private readonly ApplicationDbContext _dbContext;

    public DeleteModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet(int id)
    {
        Category = _dbContext.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        var categoryFromDb = _dbContext.Category.Find(Category.Id);

        if (categoryFromDb == null)
            return Page();

        _dbContext.Category.Remove(categoryFromDb);
        await _dbContext.SaveChangesAsync();
        TempData["success"] = "Category deleted successfully";
        return RedirectToPage("Index");
    }

}