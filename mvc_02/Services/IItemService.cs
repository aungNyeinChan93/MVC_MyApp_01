using mvc_02.Dtos.Items;
using mvc_02.Models;

namespace mvc_02.Services
{
    public interface IItemService
    {
        Task<Item?> CreateAsync(CreateItemDto createItemDto);
        Task<bool> DeleteAsync(int id);
        Task<List<Item>?> GetAllAsync();
        Task<Item?> GetOneAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateItemDto updateItemDto);
    }
}