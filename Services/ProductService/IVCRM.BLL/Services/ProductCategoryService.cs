using AutoMapper;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class ProductCategoryService : BaseService<ProductCategory, ProductCategoryEntity>, IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper) : base (repository, mapper)
        {
            _productCategoryRepository = repository;
        }

    public IEnumerable<ProductCategory> GetCategoriesTree()
        {
            var entities = _productCategoryRepository.GetCategoriesTree();

            return _mapper.Map<IEnumerable<ProductCategory>>(entities);
        }
    }
}
