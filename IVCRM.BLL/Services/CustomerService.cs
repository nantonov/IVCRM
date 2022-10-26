using AutoMapper;
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

        public async Task<Customer> Create(Customer request)
        {
            var mappedRequest = _mapper.Map<CustomerEntity>(request);
            var responce =  await _customerRepository.Create(mappedRequest);

            return _mapper.Map<Customer>(responce);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var responce = await _customerRepository.GetAll();

            return _mapper.Map<IEnumerable<Customer>>(responce);
        }

        public async Task<Customer> GetById(int id)
        {
            var responce = await _customerRepository.GetById(id);

            return _mapper.Map<Customer>(responce);
        }

        public async Task<Customer> Update(Customer request)
        {
            var mappedRequest = _mapper.Map<CustomerEntity>(request);
            var responce = await _customerRepository.Update(mappedRequest);

            return _mapper.Map<Customer>(responce);
        }

        public async Task<Customer> Delete(int id)
        {
            var responce = await _customerRepository.Delete(id);

            return _mapper.Map<Customer>(responce);
        }
    }
}
