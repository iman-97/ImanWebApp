using ImanWebApp.DataAccess.Data;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes;

public class DeleteModel : PageModel
{
    [BindProperty]
    public FoodType FoodType { get; set; }

    private readonly ApplicationDbContext _dbContext;

    public DeleteModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet(int id)
    {
        FoodType = _dbContext.FoodType.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        var foodTypeFromDb = _dbContext.FoodType.Find(FoodType.Id);

        if (foodTypeFromDb == null)
            return Page();

        _dbContext.FoodType.Remove(foodTypeFromDb);
        await _dbContext.SaveChangesAsync();
        TempData["success"] = "FoodType deleted successfully";
        return RedirectToPage("Index");
    }

}
