using IVCRM.DAL.Entities.Interfaces;

namespace IVCRM.DAL.Entities
{
    public class CustomerEntity : IEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
    }
}
