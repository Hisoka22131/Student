using StMagazine.Interfaces;
using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.SQLRepository
{
    public class SQLItemRepository : IItemRepository
    {
        private readonly ApplicationContext context;
        public SQLItemRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Item Add(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }

        public Item Delete(int id)
        {
            Item item = context.Items.Find(id);
            if (item != null)
            {
                context.Items.Remove(item);
                context.SaveChanges();
            }
            return item;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return context.Items;
        }

        public Item GetItemId(int itemId)
        {
            return context.Items.Find(itemId);
        }

        public Item Update(Item itemChanges)
        {
            var item = context.Items.Attach(itemChanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return itemChanges;
        }
    }
}
