using ImanWebApp.Models;

namespace ImanWebApp.DataAccess.Repositiory.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
}
