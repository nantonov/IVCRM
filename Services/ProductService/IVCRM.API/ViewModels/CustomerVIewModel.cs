using IVCRM.Core.Models;

namespace IVCRM.API.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
