using System.Security.Claims;
using AuthorizationService.DAL.Entities;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Extensions;

namespace AuthorizationService.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<User> claimsPrincipalFactory;
        private readonly UserManager<User> userManager;

        public ProfileService(UserManager<User> userManager, IUserClaimsPrincipalFactory<User> claimsPrincipalFactory)
        {
            this.userManager = userManager;
            this.claimsPrincipalFactory = claimsPrincipalFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            var roles = await userManager.GetRolesAsync(user);

            var principal = await claimsPrincipalFactory.CreateAsync(user);

            var claims = principal.Claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            claims.Add(new Claim(ClaimTypes.Role, roles.First()));
            claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));


            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
