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

        public async Task<bool> UpdateAsync(int id,UpdateItemDto updateItemDto)
        {
            if (updateItemDto is null)
            {
                return default!;
            }

            var item = await _context.Items.AsNoTracking().FirstOrDefaultAsync(i=> i.ItemId == id);

            if (item is null)
            {
                return false;
            }

            item.Name = updateItemDto.Name;
            item.Price = updateItemDto.Price;
            item.CategoryId = updateItemDto.CategoryId;

            _context.Entry(item).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result >= 1 ? true : false;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Items.AsNoTracking().FirstOrDefaultAsync(i => i.ItemId == id);
            if (item is null)
            {
                return false;
            }
            _context.Items.Remove(item);
            _context.Entry(item).State = EntityState.Deleted;
            var result = await _context.SaveChangesAsync();
            return result >=1 ? true : false;

        }
    }
}
