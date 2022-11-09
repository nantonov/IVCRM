using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<IdentityUser> userManager;

        public ProfileService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {/*
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            var roles = await userManager.GetRolesAsync(user);

            var principal = await claimsPrincipalFactory.CreateAsync(user);

            var claims = principal.Claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            claims.Add(new Claim(JwtClaimTypes.MiddleName, user.MiddleName));
            claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, roles.First()));

            context.IssuedClaims = claims;*/
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {/*
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            context.IsActive = user != null;*/
        }
    }
}
