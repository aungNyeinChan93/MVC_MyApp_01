namespace mvc_02.Dtos.Items
{
    public class UpdateItemDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
