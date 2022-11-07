using System.ComponentModel.DataAnnotations;

namespace StockManagement.API.ViewModels
{
    public class ChangeProductViewModel
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
