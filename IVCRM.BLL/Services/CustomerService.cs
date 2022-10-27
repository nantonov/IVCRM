using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
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

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var entity = await _customerRepository.GetAll();

            return _mapper.Map<IEnumerable<Customer>>(entity);
        }

        public async Task<Customer> GetById(int id)
        {
            var entity = await _customerRepository.GetById(id);

            return _mapper.Map<Customer>(entity);
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

        public async Task<Customer> Delete(int id)
        {
            if (!await IsEntityExists(id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = await _customerRepository.Delete(id);

            return _mapper.Map<Customer>(entity);
        }

        public async Task<bool> IsEntityExists(int id)
        {
            var entity = await _customerRepository.GetById(id);

            return entity is not null;
        }
    }
}
