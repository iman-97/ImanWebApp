using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ImanWeb.Pages.Admin.MenuItems;

[BindProperties]
public class UpsertModel : PageModel
{
    public MenuItem MenuItem { get; set; }
    public IEnumerable<SelectListItem> CategoryList { get; set; }
    public IEnumerable<SelectListItem> FoodTypeList { get; set; }

    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
        MenuItem = new();
    }

    public void OnGet()
    {
        CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
        {
            Text = i.Name,
            Value = i.Id.ToString()
        });

        FoodTypeList = _unitOfWork.FoodType.GetAll().Select(i => new SelectListItem()
        {
            Text = i.Name,
            Value = i.Id.ToString()
        });
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid == false)
            return Page();

        var webRootPath = _hostEnvironment.WebRootPath; //wwwroot path
        var files = HttpContext.Request.Form.Files; //getting the uploaded image

        if (MenuItem.Id == 0)
        {
            //Create
            var fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images\menuItems");
            var extention = Path.GetExtension(files[0].FileName);

            using(var fileStream=new FileStream(Path.Combine(uploads, fileName_new + extention), FileMode.Create))
            {
                files[0].CopyTo(fileStream); // upload image to server
            }

            MenuItem.ImageUrl = @"\images\menuItems\" + fileName_new + extention;
            _unitOfWork.MenuItem.Add(MenuItem);
            _unitOfWork.Save();
        }
        else
        {
            //edit
        }

        return RedirectToPage("./Index");
    }

}
