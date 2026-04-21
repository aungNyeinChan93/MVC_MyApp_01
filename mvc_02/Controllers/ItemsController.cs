using Microsoft.AspNetCore.Mvc;
using mvc_02.Dtos.Items;
using mvc_02.Services;

namespace mvc_02.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ItemService _itemService;

        private readonly CategoryService categoryService;

        public ItemsController(ItemService itemService, CategoryService categoryService)
        {
            _itemService = itemService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _itemService.GetAllAsync();
            return View(items);
        }

        [HttpGet] 
        [ActionName("Detail")]
        public async Task<IActionResult> ItemDetail(int id)
        {
            var item = await _itemService.GetOneAsync(id);
            return View("ItemDetail",item);
        }

        [HttpGet]
        [ActionName("Create")]
        public async Task<IActionResult> ItemCreate()
        {
            var categories = await categoryService.GetAllAsync();
            return View("ItemCreate",categories);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> ItemSave(CreateItemDto createItemDto)
        {
            if (int.TryParse(Request.Form["CategoryId"], out var categoryId))
            {
                createItemDto.CategoryId = categoryId;
            };

            //createItemDto.CategoryId = int.Parse(Request.Form["CategoryId"]!);

            var item = await _itemService.CreateAsync(createItemDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> ItemEdit()
        {
            return View("ItemEdit");
        }
    }
}
