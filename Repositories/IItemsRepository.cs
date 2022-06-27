using Catlog.Entities;

namespace Catlog.Repositories{

   public interface IInMenuItemRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> getItems();

        void createItem(Item item);

        void updateItem(Item item);

        void deletItem(Item item);
    }
}