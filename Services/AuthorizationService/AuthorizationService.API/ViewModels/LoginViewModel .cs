using System.ComponentModel.DataAnnotations;

namespace AuthorizationService.API.ViewModels
{
    public class LoginViewModel
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public bool IsRemember { get; set; }
        public string? ReturnUrl { get; set; }
    }
}