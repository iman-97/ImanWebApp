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

    public void OnGet(int? id)
    {
        if(id != null)
        {
            //Edit
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
        }

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
            var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(i => i.Id == MenuItem.Id);

            if (files.Count > 0)
            {
                //a new image uploaded
                var fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menuItems");
                var extention = Path.GetExtension(files[0].FileName);

                //delete the old image
                var oldImagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath) == true)
                    System.IO.File.Delete(oldImagePath);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extention), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                MenuItem.ImageUrl = @"\images\menuItems\" + fileName_new + extention;
            }
            else
            {
                MenuItem.ImageUrl = objFromDb.ImageUrl;
            }

            _unitOfWork.MenuItem.Update(MenuItem);
            _unitOfWork.Save();
        }

        return RedirectToPage("./Index");
    }

}
