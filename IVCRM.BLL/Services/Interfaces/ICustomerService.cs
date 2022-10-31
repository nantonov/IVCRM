﻿using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Create(Customer model);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> Update(Customer model);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
