using Catlog.Dtos;
using Catlog.Entities;

namespace Catlog{

    public static class Extensions{

        public static ItemDto AsItemDto(this Item item) => new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreatedDate = item.CreatedDate
        };

    } 
}