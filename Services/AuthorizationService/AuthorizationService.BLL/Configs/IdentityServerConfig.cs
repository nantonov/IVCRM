using System;
using System.Collections.Generic;
using System.Linq;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

namespace SPWB.AuthorizationService.Dependencies.Configs
{
    internal static class IdentityServerConfig
    {
        private static PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        internal static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        internal static IEnumerable<IdentityUser> Users => new List<IdentityUser>
        {
            new IdentityUser
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "1221")
            },
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
            new Client()
            {
                ClientId = "swaggerClient",
                ClientSecrets = 
                { 
                    new Secret("secret".ToSha256()) 
                },
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,
                RedirectUris = {"https://localhost:7159/swagger/oauth2-redirect.html"},
                AllowedCorsOrigins = {"https://localhost:7159"},
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                }
            },
        };
    }
}
