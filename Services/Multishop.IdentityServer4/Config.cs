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
            new ApiResource("Resource-ApiGateway") {Scopes = { "ApiGatewayFullPermission" } },
            new ApiResource("Resource-Catalog") {Scopes = { "CatalogFullPermission", "CatalogReadPermission"} },
            new ApiResource("Resource-Discount") {Scopes = { "DiscountFullPermission" } },
            new ApiResource("Resource-Order") {Scopes = { "OrderFullPermission" } },
            new ApiResource("Resource-Cargo") {Scopes = { "CargoFullPermission", "CargoReadPermission" } },
            new ApiResource("Resource-Basket") {Scopes = { "BasketFullPermission" } },
            new ApiResource("Resource-Comment") {Scopes = { "CommentFullPermission" } },
            new ApiResource("Resource-Payment") {Scopes = { "PaymentFullPermission" } },
            new ApiResource("Resource-Image") {Scopes = { "ImageFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("OcelotFullPermission", "Full authority for ocelot microservices processes"),
            new ApiScope("CatalogFullPermission", "Full authority for catalog microservices processes"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog microservices processes"),
            new ApiScope("DiscountFullPermission", "Full authority for discount microservices processes"),
            new ApiScope("OrderFullPermission", "Full authority for order microservices processes"),
            new ApiScope("CargoFullPermission", "Full authority for cargo microservices processes"),
            new ApiScope("CargoReadPermission", "Reading authority for cargo microservices processes"),
            new ApiScope("BasketFullPermission", "Full authority for basket microservices processes"),
            new ApiScope("CommentFullPermission", "Full authority for comment microservices processes"),
            new ApiScope("PaymentFullPermission", "Full authority for payment microservices processes"),
            new ApiScope("ImageFullPermission", "Full authority for image microservices processes"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // visitor
            new Client
            {
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "ApiGatewayFullPermission", "CatalogReadPermission", "CatalogFullPermission", "CommentFullPermission", "DiscountFullPermission" },
                ClientId = "Multishop.VisitorId",
                ClientName = "Multishop.VisitorName",
                ClientSecrets = {new Secret("multishop.clientsecret".Sha256())}
            },

            // manager
            new Client
            {
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "ApiGatewayFullPermission", "BasketFullPermission", "CatalogFullPermission", "CommentFullPermission", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                ClientId = "Multishop.ManagerId",
                ClientName = "Multishop.ManagerName",
                ClientSecrets = {new Secret("multishop.clientsecret".Sha256())}
            },

            // admin
            new Client
            {
                AccessTokenLifetime = 600, // 600 seconds => 10 minutes
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "ApiGatewayFullPermission", "BasketFullPermission", "CatalogFullPermission", "CargoFullPermission", "CommentFullPermission", "DiscountFullPermission", "OrderFullPermission", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                ClientId = "Multishop.AdminId",
                ClientName = "Multishop.AdminName",
                ClientSecrets = {new Secret("multishop.clientsecret".Sha256())}
            }
        };
    }
}