namespace IVCRM.DAL.Entities
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Product? Product { get; set; }
        public Order? Order { get; set; }

        public float Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
