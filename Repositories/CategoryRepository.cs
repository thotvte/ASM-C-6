using web_ban_do_an.Data;
using web_ban_do_an.Models;
namespace web_ban_do_an.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Category Category)
        {
            _context.Category.Add(Category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Category = _context.Category.Find(id);
            if (Category != null)
            {
                _context.Category.Remove(Category);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Category.Find(id);
        }

        public void Update(Category Category)
        {
            _context.Category.Update(Category);
            _context.SaveChanges();
        }
    }
}
