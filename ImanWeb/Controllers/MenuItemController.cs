using ImanWebApp.DataAccess.Repositiory.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ImanWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController : Controller
{
	private readonly IUnitOfWork _unitOfWork;

	public MenuItemController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	[HttpGet]
	public IActionResult Get()
	{
		var menuItemList = _unitOfWork.MenuItem.GetAll();
		return Json(new { data = menuItemList });
	}
}
