using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;

namespace ImanWebApp.DataAccess.Repositiory;

public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
{
    private readonly MyApplicationDbContext _db;

    public MenuItemRepository(MyApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(MenuItem menuItem)
    {
        var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == menuItem.Id);
        objFromDb.Name = menuItem.Name;
        objFromDb.Description = menuItem.Description;
        objFromDb.Price = menuItem.Price;
        objFromDb.CategoryId = menuItem.CategoryId;
        objFromDb.FoodTypeId = menuItem.FoodTypeId;

        if(objFromDb.ImageUrl != null)
        {
            objFromDb.ImageUrl = menuItem.ImageUrl;
        }
    }

}
