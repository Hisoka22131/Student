using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.ViewModels.IViewModel
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public PageViewModel PageViewModel { get; }
        public ItemListViewModel(IEnumerable<Item> items, PageViewModel viewModel)
        {
            Items = items;
            PageViewModel = viewModel;
        }
    }
}
