namespace IVCRM.BLL.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }

        public Product? Product { get; set; }
    }
}
