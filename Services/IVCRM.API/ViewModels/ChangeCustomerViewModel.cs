using System.ComponentModel.DataAnnotations;

namespace IVCRM.API.ViewModels
{
    public class ChangeCustomerViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
