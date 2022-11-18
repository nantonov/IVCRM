using AuthorizationService.DAL.Entities;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using static IdentityServer4.Models.IdentityResources;
using Role = AuthorizationService.DAL.Enums.Role;

namespace AuthorizationService.BLL.Configs
{
    internal static class IdentityServerConfig
    {
        internal static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new OpenId(),
            new Profile(),
            new Email(),
        };

        internal static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("productAPI", "Full access to productAPI"),
        };

        internal static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {
            new ApiResource("productAPI", "Product API") {Scopes = {"productAPI"}}
        };

        internal static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "swaggerClient",
                ClientName = "Swagger UI",
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,
                RedirectUris = {"https://localhost:7159/swagger/oauth2-redirect.html"},
                AllowedCorsOrigins = {"https://localhost:7159"},
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
                    "productAPI"}
            },
            new Client()
                {
                    ClientId = "react-client",
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,
                    ClientName = "React Client",
                    AllowedCorsOrigins = {"http://localhost:3000"},
                    RedirectUris = { "http://localhost:3000/callback", "http://localhost:3000/refresh" },
                    PostLogoutRedirectUris = { "http://localhost:3000/logout" },
                    AllowedGrantTypes =  GrantTypes.Code,
                    AllowOfflineAccess = true,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "productAPI",
                    }
            }
        };

        internal static User TestUser => new User
        {
            UserName = "alice",
            Email = "AliceSmith@email.com",
        };

        internal static IEnumerable<string> Roles => Enum.GetValues(typeof(Role))
            .Cast<Role>()
            .Select(x => x.ToString());
    }
}
