using ImanWebApp.DataAccess.Data;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes;

public class EditModel : PageModel
{
    [BindProperty]
    public FoodType FoodType { get; set; }

    private readonly ApplicationDbContext _dbContext;

    public EditModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet(int id)
    {
        FoodType = _dbContext.FoodType.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        _dbContext.Update(FoodType);
        await _dbContext.SaveChangesAsync();
        TempData["success"] = "FoodType updated successfully";
        return RedirectToPage("Index");
    }

}
