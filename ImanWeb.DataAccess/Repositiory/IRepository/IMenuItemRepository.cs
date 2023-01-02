using ImanWebApp.Models;

namespace ImanWebApp.DataAccess.Repositiory.IRepository;

public interface IMenuItemRepository:IRepository<MenuItem>
{
    void Update(MenuItem menuItem);
}
