namespace WebApiAdvance.Entities.DTOs.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
    }
}
