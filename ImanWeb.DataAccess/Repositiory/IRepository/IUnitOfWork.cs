namespace ImanWebApp.DataAccess.Repositiory.IRepository;

public interface IUnitOfWork : IDisposable
{
	ICategoryRepository Category { get; }
	IFoodTypeRepository FoodType { get; }
	IMenuItemRepository MenuItem { get; }

	void Save();
}
