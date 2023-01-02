using ImanWebApp.DataAccess.Data;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes;

public class CreateModel : PageModel
{
    [BindProperty]
    public FoodType FoodType { get; set; }

    private readonly ApplicationDbContext _dbContext;

    public CreateModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        await _dbContext.FoodType.AddAsync(FoodType);
        await _dbContext.SaveChangesAsync();
        TempData["success"] = "FoodType created successfully";
        return RedirectToPage("Index");
    }

}
