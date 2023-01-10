using IVCRM.BLL.Models.Interfaces;

namespace IVCRM.BLL.Models
{
    public class Product : IModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PictureUri { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
