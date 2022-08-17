using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StMagazine.Interfaces;
using StMagazine.Models;
using StMagazine.ViewModels;
using StMagazine.ViewModels.IViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public ViewResult Index(string Name, int page = 1)
        {
            //var model = _itemRepository.GetAllItems();
            int pageSize = 3;
            IEnumerable<Item> items = _itemRepository.GetAllItems();
            if (!String.IsNullOrEmpty(Name))
                items = items.Where(n => n.ItemName.Contains(Name));
            var count = items.Count();
            var skip = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ItemListViewModel ivm = new ItemListViewModel(skip, pageViewModel);
            return View(ivm);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id != null)
            {
                Item item = _itemRepository.GetItemId(id);
                ItemDeleteViewModel itemDeleteViewModel = new ItemDeleteViewModel
                {
                    Name = item.ItemName,
                    Teacher = item.Teacher,
                    Id = item.Id
                };
                return View(itemDeleteViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Item item = _itemRepository.GetItemId(id);
            if (item !=null)
            {
                _itemRepository.Delete(id);
                return RedirectToAction("Index");
            };
            return NotFound();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ItemCreateViewModel itemCreateViewModel)
        {
            if (itemCreateViewModel != null)
            {
                Item newItem = new Item
                {
                    ItemName = itemCreateViewModel.Name,
                    Teacher = itemCreateViewModel.Teacher
                };
                _itemRepository.Add(newItem);
                return RedirectToAction("Index", new { id = newItem.Id });
            };
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != null)
            {
                Item item = _itemRepository.GetItemId(id);
                ItemEditViewModel itemEditViewModel = new ItemEditViewModel
                {
                    Id = item.Id,
                    Name = item.ItemName,
                    Teacher = item.Teacher
                };
                return View(itemEditViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Edit(ItemEditViewModel model)
        {
            Item item = _itemRepository.GetItemId(model.Id);
            item.ItemName = model.Name;
            item.Teacher = model.Teacher;
            _itemRepository.Update(item);
            return RedirectToAction("Index");
        }
    }
}
