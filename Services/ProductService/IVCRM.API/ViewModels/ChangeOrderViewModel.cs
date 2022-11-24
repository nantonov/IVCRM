using IVCRM.API.ViewModels.Enums;

namespace IVCRM.API.ViewModels
{
    public class ChangeOrderViewModel
    {
        public string? Name { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
