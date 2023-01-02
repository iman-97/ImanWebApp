using ImanWebApp.Models;

namespace ImanWebApp.DataAccess.Repositiory.IRepository;

public interface IFoodTypeRepository : IRepository<FoodType>
{
    void Update(FoodType foodType);
}
