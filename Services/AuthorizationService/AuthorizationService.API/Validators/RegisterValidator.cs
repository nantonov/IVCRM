using FluentValidation;
using AuthorizationService.API.ViewModels;

namespace AuthorizationService.API.Validators
{
    public class RegisterValidator : AbstractValidator<LoginViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Login is required")
                .MinimumLength(2)
                .WithMessage("Login must be at least 2 symbols")
                .MaximumLength(50)
                .WithMessage("Login is too long");
        }

        /*
                 public string Login { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Range(0, 120)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
         */
    }
}
