using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventorySystemWebApp.Models;

namespace InventorySystemWebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemWebsiteDB _itemWebsiteDB;

        public ItemController(ItemWebsiteDB itemWebsiteDB)
        {
            _itemWebsiteDB = itemWebsiteDB;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _itemWebsiteDB.Items.ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                int ID = _itemWebsiteDB.Items.Count() + 1;
                item.ID = ID;
                _itemWebsiteDB.Items.Add(item);
                await _itemWebsiteDB.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _itemWebsiteDB.Items.FindAsync(id);
            if (item == null)
                return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Item item)
        {
            if (id != item.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                _itemWebsiteDB.Entry(item).State = EntityState.Modified;
                await _itemWebsiteDB.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemWebsiteDB.Items.FindAsync(id);
            if (item == null)
                return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _itemWebsiteDB.Items.FindAsync(id);
            if (item != null)
            {
                _itemWebsiteDB.Items.Remove(item);
                await _itemWebsiteDB.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}

