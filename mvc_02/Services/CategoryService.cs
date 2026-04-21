using Microsoft.EntityFrameworkCore;
using mvc_02.Data;
using mvc_02.Models;

namespace mvc_02.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.AsNoTracking().Include(c=>c.Items).ToListAsync();
            return categories;
        }
    }
}
