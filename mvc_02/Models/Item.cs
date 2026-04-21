using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_02.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }

        public Category? Category { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
    }
}
