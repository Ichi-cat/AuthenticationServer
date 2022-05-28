using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthenticationServer
{
    internal static class Configuration
    {
        internal static IEnumerable<ApiScope> GetScopes() =>
            new List<ApiScope>
            {
                new ApiScope("NotesAPI", "Notes")
            };
        internal static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        internal static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("NotesWebApi", "NotesApi", new [] { JwtClaimTypes.Name })
                {
                    Scopes = { "NotesAPI" }
                }
            };
        internal static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "C7B53111-019B-4781-AFFF-71B6F6B0D277",
                    //ClientSecrets = { new Secret("yhebH!hDqwedh6539@".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = false,//
                    RedirectUris =
                    {
                        "https://oauth.pstmn.io/v1/callback"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://oauth.pstmn.io"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NotesAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
