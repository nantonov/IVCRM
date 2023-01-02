namespace IVCRM.API.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public AddressViewModel? Address { get; set; }
        public ICollection<OrderViewModel>? Orders { get; set; }
    }
}
