using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.BLL.Validators
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private UserManager<IdentityUser> _userManager;
        public ResourceOwnerPasswordValidator(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByNameAsync(context.UserName);
            if (user is null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect user name");
                return;
            }

            var isPasswordChecked = await _userManager.CheckPasswordAsync(user, context.Password);
            if (!isPasswordChecked)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                return;
            }

            context.Result = new GrantValidationResult(
                subject: user.Id.ToString(),
                authenticationMethod: "custom",
                claims: await _userManager.GetClaimsAsync(user));
            return;
        }
    }
}
