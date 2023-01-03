﻿using ImanWebApp.DataAccess.Repositiory.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ImanWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController : Controller
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _hostEnvironment;

	public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
	{
		_unitOfWork = unitOfWork;
		_hostEnvironment = hostEnvironment;
	}

	[HttpGet]
	public IActionResult Get()
	{
		var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
		return Json(new { data = menuItemList });
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(i => i.Id == id);

        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));

        if (System.IO.File.Exists(oldImagePath) == true)
            System.IO.File.Delete(oldImagePath);

        _unitOfWork.MenuItem.Remove(objFromDb);
		_unitOfWork.Save();
		return Json(new { success = true, message = "Delete suceessful." });
	}
}
