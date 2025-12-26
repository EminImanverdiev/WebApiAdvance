namespace WebApiAdvance.Entities.DTOs.Orders
{
    public class UpdateOrderDto
    {
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
