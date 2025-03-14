using BillSystemHsenid.Models;
using BillSystemHsenid.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BillSystemHsenid.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _itemRepository.GetAllItems();
            return View(items.ToList());
        }


        

        public async Task<IActionResult> Create()
        {
           
            var defineItems = await _itemRepository.getAllDefineItems();
            ViewBag.DefineItems = defineItems;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Items item)
        {
            if (ModelState.IsValid)
            {
                await _itemRepository.AddNewItem(item);

                return RedirectToAction("Index");
                

            }

            return View(item);




        }

    }
}
