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
            try
            {
                var items = await _itemRepository.GetAllItems();
                return View(items.ToList());

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<DefineItems>());
            }
        
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DefineItems item)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _itemRepository.AddNewItem(item);

                    return RedirectToAction("Index");


                }

                return View(item);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(item);
            }

        }

    }
}
