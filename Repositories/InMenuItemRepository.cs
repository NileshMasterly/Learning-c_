using Catlog.Entities;
using System;
using System.Collections.Generic;


namespace Catlog.Repositories{


    public class InMenuItemRepository : IInMenuItemRepository
    {

        private readonly List<Item> items = new(){
            new Item{Id = Guid.NewGuid(),Name = "Iron Suit",Price =10,CreatedDate = DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "Iron Shiled",Price =9,CreatedDate = DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "Hammer",Price =12,CreatedDate = DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "Sword",Price =14,CreatedDate = DateTimeOffset.UtcNow},
        };

        public IEnumerable<Item> getItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            var item = items.FirstOrDefault(item => item.Id == id);
            return item??new Item{Id = Guid.NewGuid(),Name = "Test",Price =14,CreatedDate = DateTimeOffset.UtcNow};
        }

        public void createItem(Item item)
        {
            items.Add(item);
        }

        public void updateItem(Item item)
        {
           var index = items.FindIndex(i => i.Id == item.Id);
            items[index] = item;
        }

        public void deletItem(Item item)
        {   
         items.Remove(item);
        }


        public void delteAllItems()
        {
           items.Clear();
        }

    }
}