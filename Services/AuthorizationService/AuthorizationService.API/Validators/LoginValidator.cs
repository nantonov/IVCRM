﻿using FluentValidation;
using AuthorizationService.API.ViewModels;

namespace AuthorizationService.API.Validators
{
    public class LoginValidator :AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("Login is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
