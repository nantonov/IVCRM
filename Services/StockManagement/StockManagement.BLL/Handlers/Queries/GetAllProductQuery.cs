using MediatR;
using StockManagement.DAL.Entities;

namespace StockManagement.BLL.Handlers.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}
