using IdentityServer4;
using IdentityServer4.Models;

namespace SPWB.AuthorizationService.Dependencies.Configs
{
    internal static class IdentityServerConfig
    {
        internal static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("productApi", "Full access to productAPI"),
        };

        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {
            new ApiResource("productApi", "Product API") {Scopes = {"productApi"}}
        };

        internal static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "testClient",
                AllowAccessTokensViaBrowser = true,
                ClientSecrets =
                {
                    new Secret("secret".Sha256()),
                },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                /*AllowedGrantTypes = new[]
                {
                    GrantType.ResourceOwnerPassword,
                    GrantType.ClientCredentials,
                    GrantType.AuthorizationCode,
                },*/
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                /*
                RedirectUris = new List<string>() { "https://oauth.pstmn.io/v1/callback" },
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                */
            },
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
                    "api1"}
            }
        };
    }
}
