using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;

namespace ImanWebApp.DataAccess.Repositiory;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly MyApplicationDbContext _db;

    public CategoryRepository(MyApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category category)
    {
        var objFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
        objFromDb.Name = category.Name;
        objFromDb.DisplayOrder = category.DisplayOrder;
    }

}
