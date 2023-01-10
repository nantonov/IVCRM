using IVCRM.BLL.Models.Enums;
using IVCRM.BLL.Models.Interfaces;

namespace IVCRM.BLL.Models
{
    public class Order : IModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
