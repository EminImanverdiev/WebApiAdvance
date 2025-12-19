using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.Entities;

public class Product: BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }

}
