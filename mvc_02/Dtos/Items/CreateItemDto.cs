using System.ComponentModel.DataAnnotations;

namespace mvc_02.Dtos.Items
{
    public class CreateItemDto
    {
        public required string Name { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
