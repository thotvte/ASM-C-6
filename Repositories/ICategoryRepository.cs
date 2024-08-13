using web_ban_do_an.Models;
namespace web_ban_do_an.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);          
        void Add(Category category);       
        void Update(Category category);     
        void Delete(int id);
    }
}
