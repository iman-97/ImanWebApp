using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;

namespace ImanWebApp.DataAccess.Repositiory;

public class UnitOfWork : IUnitOfWork
{
	private readonly MyApplicationDbContext _db;

	public UnitOfWork(MyApplicationDbContext db)
	{
		_db = db;
		Category = new CategoryRepository(_db);
		FoodType = new FoodTypeRepository(_db);
		MenuItem = new MenuItemRepository(_db);
	}

	public ICategoryRepository Category { get; private set; }
	public IFoodTypeRepository FoodType { get; private set; }
	public IMenuItemRepository MenuItem { get; private set; }

	public void Dispose()
	{
		_db.Dispose();
	}

	public void Save()
	{
		_db.SaveChanges();
	}

}
