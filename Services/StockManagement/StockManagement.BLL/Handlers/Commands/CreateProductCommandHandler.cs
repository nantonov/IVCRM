using AutoMapper;
using MediatR;

using StockManagement.DAL.Entities;
using StockManagement.DAL.Repositories.Interfaces;

namespace StockManagement.BLL.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductEntity>(command);
            var product = await _repository.Create(entity);
            return _mapper.Map<Product>(product);
        }
    }
}
