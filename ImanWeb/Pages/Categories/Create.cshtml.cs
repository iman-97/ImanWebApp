using ImanWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public Category Category { get; set; }

        public void OnGet()
        {
        }

    }
}
