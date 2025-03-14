using BillSystemHsenid.Models;
using BillSystemHsenid.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BillSystemHsenid.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepository;
        private readonly IItemRepository _itemRepository;

        public BillController(IBillRepository billRepository, IItemRepository itemRepository)
        {
            _billRepository = billRepository;
            _itemRepository = itemRepository;
        }

        public async Task<IActionResult> Index()
        {
            var bills = await _billRepository.GetAllBills();
            return View(bills);
        }

        public async Task<IActionResult> Create()
        {
            var items = await _itemRepository.GetAllItems();
            ViewBag.Items = items;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                await _billRepository.CreateBill(bill);
                return RedirectToAction("Index");
            }
            return View(bill);
        }
    }
}
