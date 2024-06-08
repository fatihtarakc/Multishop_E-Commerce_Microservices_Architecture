// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Multishop.IdentityServer4
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("Resource-Catalog") {Scopes = { "CatalogFullPermission", "CatalogReadPermission"} },
            new ApiResource("Resource-Discount") {Scopes = { "DiscountFullPermission" } },
            new ApiResource("Resource-Order") {Scopes = { "OrderFullPermission" } }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog microservices processes"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog microservices processes"),
            new ApiScope("DiscountFullPermission", "Full authority for discount microservices processes"),
            new ApiScope("OrderFullPermission", "Full authority for order microservices processes")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // visitor
            new Client
            {
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "CatalogReadPermission" },
                ClientId = "Multishop.VisitorId",
                ClientName = "Multishop.VisitorName",
                ClientSecrets = {new Secret("multishop.visitor".Sha256())}
            },

            // manager
            new Client
            {
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "CatalogFullPermission" },
                ClientId = "Multishop.ManagerId",
                ClientName = "Multishop.ManagerName",
                ClientSecrets = {new Secret("multishop.manager".Sha256())}
            },

            // admin
            new Client
            {
                AccessTokenLifetime = 600, // 600 seconds => 10 minutes
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                ClientId = "Multishop.AdminId",
                ClientName = "Multishop.AdminName",
                ClientSecrets = {new Secret("multishop.admin".Sha256())}
            }
        };

        //public static IEnumerable<IdentityResource> IdentityResources =>
        //           new IdentityResource[]
        //           {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //           };

        //public static IEnumerable<ApiScope> ApiScopes =>
        //    new ApiScope[]
        //    {
        //        new ApiScope("scope1"),
        //        new ApiScope("scope2"),
        //    };

        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        // m2m client credentials flow client
        //        new Client
        //        {
        //            ClientId = "m2m.client",
        //            ClientName = "Client Credentials Client",

        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

        //            AllowedScopes = { "scope1" }
        //        },

        //        // interactive client using code flow + pkce
        //        new Client
        //        {
        //            ClientId = "interactive",
        //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44300/signin-oidc" },
        //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
        //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

        //            AllowOfflineAccess = true,
        //            AllowedScopes = { "openid", "profile", "scope2" }
        //        },
        //    };
    }
}