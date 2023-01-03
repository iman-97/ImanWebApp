using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImanWeb.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MenuItem> MenuItemList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public void OnGet()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            CategoryList = _unitOfWork.Category.GetAll(orderby: x => x.OrderBy(c => c.DisplayOrder));
        }
    }
}
