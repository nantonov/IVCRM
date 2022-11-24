using IVCRM.BLL.Models.Enums;

namespace IVCRM.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
