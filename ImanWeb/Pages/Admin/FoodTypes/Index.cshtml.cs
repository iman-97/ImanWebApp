using ImanWebApp.DataAccess.Data;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        public IEnumerable<FoodType> FoodTypes { get; set; }

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            FoodTypes = _db.FoodType;
        }

    }
}
