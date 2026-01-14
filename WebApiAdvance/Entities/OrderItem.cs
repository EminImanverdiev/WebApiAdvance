using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.Entities
{
    public class OrderItem : BaseEntity
    {

        public string Description { get; set; }

        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }
}
}
