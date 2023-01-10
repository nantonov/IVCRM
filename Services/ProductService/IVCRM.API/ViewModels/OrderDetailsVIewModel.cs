using IVCRM.API.ViewModels.Enums;

namespace IVCRM.API.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }

        public CustomerViewModel? Customer { get; set; }
        public ICollection<OrderItemViewModel>? OrderItems { get; set; }
    }
}
