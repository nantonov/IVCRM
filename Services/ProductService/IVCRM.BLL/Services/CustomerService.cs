using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.Core;
using IVCRM.Core.Models;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> Create(Customer model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            var result =  await _customerRepository.Create(entity);

            return _mapper.Map<Customer>(result);
        }

        public async Task<PagedList<Customer>> GetAll(TableParameters parameters)
        {
            var entities = await _customerRepository.GetAll(parameters);

            return _mapper.Map<PagedList<Customer>>(entities);
        }

        public async Task<CustomerDetails> GetById(int id)
        {
            var entity = await _customerRepository.GetById(id);

            return _mapper.Map<CustomerDetails>(entity);
        }

        public async Task<Customer> Update(Customer model)
        {
            if (!await IsEntityExists(model.Id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = _mapper.Map<CustomerEntity>(model);
            var result = await _customerRepository.Update(entity);

            return _mapper.Map<Customer>(result);
        }

        public async Task Delete(int id)
        {
            if (!await IsEntityExists(id))
            {
                throw new ResourceNotFoundException();
            }

            await _customerRepository.Delete(id);
        }

        public async Task<bool> IsEntityExists(int id)
        {
            var entity = await _customerRepository.GetById(id);

            return entity is not null;
        }
    }
}
