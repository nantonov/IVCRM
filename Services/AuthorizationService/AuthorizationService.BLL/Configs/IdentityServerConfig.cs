using AuthorizationService.DAL.Entities;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.BLL.Configs
{
    internal static class IdentityServerConfig
    {
        internal static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
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
            }
        };

        internal static User TestUser => new User
        {
            UserName = "alice",
        };
    }
}
