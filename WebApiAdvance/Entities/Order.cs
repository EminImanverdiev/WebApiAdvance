using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.Entities
{
    public class Order : BaseEntity
    {

        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}
