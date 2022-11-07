using MediatR;
using StockManagement.DAL.Entities;

namespace StockManagement.BLL.Handlers.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
