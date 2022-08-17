using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Interfaces
{
   public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemId(int itemId);
        Item Add(Item item);
        Item Update(Item itemChanges);
        Item Delete(int id);
    }
}
