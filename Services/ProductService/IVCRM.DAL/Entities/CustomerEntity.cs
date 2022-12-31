using IVCRM.DAL.Entities.Interfaces;

namespace IVCRM.DAL.Entities
{
    public class CustomerEntity : IEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }
        public string Notes { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
    }
}
