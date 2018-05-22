using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Banco.Ripley.STS.Configuration
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ripley.api", "Ripley API")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ripley.postman",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("0D1438E8-E027-43A3-8C70-773E155405DC".Sha256())
                    },
                    AllowedScopes = { "ripley.api" }
                },
                new Client
                {
                    ClientId = "ripley.web",
                    ClientName = "Ripley Web",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("871FB92D-561A-49ED-824F-6EEEEA0B7794".Sha256())
                    },
                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ripley.api"
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "eflorespalma",
                    Password = "123456",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Edgar Flores P."),
                        new Claim("website", "https://github.com/eflorespalma")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "rhuanca",
                    Password = "123456",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Roberto Huanca"),
                        new Claim("website", "https://bob.com")
                    }
                }
            };
        }
    }
}
