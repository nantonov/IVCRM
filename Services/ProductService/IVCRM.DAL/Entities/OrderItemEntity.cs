namespace IVCRM.DAL.Entities
{
    public class OrderItemEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public ProductEntity? Product { get; set; }
        public OrderEntity? Order { get; set; }

        public float Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
