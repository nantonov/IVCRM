using AutoMapper;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.Core;
using IVCRM.Core.Models;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class CustomerService : BaseService<Customer, CustomerEntity>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _customerRepository = repository;
        }

        public async Task<PagedList<Customer>> GetAll(TableParameters parameters)
        {
            var entities = await _customerRepository.GetAll(parameters);

            return _mapper.Map<PagedList<Customer>>(entities);
        }

        public new async Task<CustomerDetails> GetById(int id)
        {
            var entity = await _customerRepository.GetById(id);

            return _mapper.Map<CustomerDetails>(entity);
        }
    }
}
