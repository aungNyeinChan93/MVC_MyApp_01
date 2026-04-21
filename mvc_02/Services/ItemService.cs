using Microsoft.EntityFrameworkCore;
using mvc_02.Data;
using mvc_02.Dtos.Items;
using mvc_02.Models;

namespace mvc_02.Services
{
    public class ItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>?> GetAllAsync()
        {
            var items = await _context.Items.AsNoTracking().Include(i=>i.Category).ToListAsync();
            return items;
        }

        public async Task<Item?> GetOneAsync(int id)
        {
            var item = await _context.Items
                    .AsNoTracking()
                    .Include(i => i.Category)
                    .FirstOrDefaultAsync(i=>i.ItemId == id);
            return item;
        }

        public async Task<Item?> CreateAsync(CreateItemDto createItemDto)
        {
            if (createItemDto is null)
            {
                return default!;
            }
            var newItem = new Item
            {
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CategoryId = createItemDto.CategoryId,
            };

            await _context.Items.AddAsync(newItem);
            var result = await _context.SaveChangesAsync();
            return result >=1 ? newItem : default!;
        }
    }
}
