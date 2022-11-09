using System;
using System.Collections.Generic;
using System.Linq;
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
                //AllowAccessTokensViaBrowser = true,
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
                    //IdentityServerConstants.StandardScopes.Profile,
                },
                /*
                RedirectUris = new List<string>() { "https://localhost:7035/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:7035/signout-callback-oidc" },
                */
            },
        };
    }
}
