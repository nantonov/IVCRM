using AutoMapper;
using MediatR;
using StockManagement.DAL.Entities;
using StockManagement.DAL.Repositories.Interfaces;

namespace StockManagement.BLL.Handlers.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IEnumerable<Product>>(entities);
        }
    }

}
