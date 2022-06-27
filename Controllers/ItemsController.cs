using Catlog.Dtos;
using Catlog.Entities;
using Catlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;

namespace Catlog.Controllers
{

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMenuItemRepository repository;

        public ItemsController(IInMenuItemRepository repository)
        {
            this.repository = repository;
        }

        // Get List of Items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.getItems().Select(item => item.AsItemDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> getItem(Guid id)
        {
            var result = repository.GetItem(id);
            if (result is null)
            {
                return NotFound();
            }
            return result.AsItemDto();
        }


        [HttpPost]
        public ActionResult<ItemDto> createItem(CreateItemDto createDto)
        {

            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = createDto.Name,
                Price = createDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.createItem(item);
            return CreatedAtAction(nameof(getItem), new { id = item.Id }, item.AsItemDto());
        }


        [HttpPut("{id}")]
        public ActionResult updateItem(Guid id, UpdateItemDto update)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            Item updateItem = existingItem with
            {
                Name = update.Name,
                Price = update.Price
            };

            repository.updateItem(updateItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteItem(Guid id){
           var existingItem = repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }
            repository.deletItem(existingItem);

            return NoContent();
        }

    }
}