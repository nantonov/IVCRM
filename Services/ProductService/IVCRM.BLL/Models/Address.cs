using IVCRM.DAL.Entities.Interfaces;

namespace IVCRM.BLL.Models
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
