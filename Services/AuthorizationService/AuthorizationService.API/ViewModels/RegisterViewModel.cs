namespace AuthorizationService.API.ViewModels
{
    public class RegisterViewModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}