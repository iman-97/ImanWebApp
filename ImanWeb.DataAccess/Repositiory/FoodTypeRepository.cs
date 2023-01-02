using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;
using ImanWebApp.Models;

namespace ImanWebApp.DataAccess.Repositiory
{
	public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
	{
		private readonly ApplicationDbContext _db;

		public FoodTypeRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(FoodType foodType)
		{
			var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == foodType.Id);
			objFromDb.Name = foodType.Name;
		}
	}
}
