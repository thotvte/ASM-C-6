using Microsoft.EntityFrameworkCore;
using web_ban_do_an.Data;
using web_ban_do_an.Models;

namespace web_ban_do_an.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }
    }
}
