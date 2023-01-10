using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class AddressService : BaseService<Address, AddressEntity>, IAddressService
    {
        public AddressService(IAddressRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<Address> Create(Address model)
        {
            var entity = _mapper.Map<AddressEntity>(model);
            var result =  await _repository.Create(entity);

            return _mapper.Map<Address>(result);
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IEnumerable<Address>>(entities);
        }

        public async Task<Address> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<Address>(entity);
        }

        public async Task<Address> Update(Address model)
        {
            if (!await IsEntityExists(model.Id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = _mapper.Map<AddressEntity>(model);
            var result = await _repository.Update(entity);

            return _mapper.Map<Address>(result);
        }

        public async Task Delete(int id)
        {
            if (!await IsEntityExists(id))
            {
                throw new ResourceNotFoundException();
            }

            await _repository.Delete(id);
        }

        public async Task<bool> IsEntityExists(int id)
        {
            var entity = await _repository.GetById(id);

            return entity is not null;
        }
    }
}
