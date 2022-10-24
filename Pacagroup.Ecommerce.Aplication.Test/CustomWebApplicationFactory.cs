﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;


namespace Pacagroup.Ecommerce.Aplication.Test
{
    public class CustomWebApplicationFactory:WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                var integracionBuilder = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .AddEnvironmentVariables()
                                        .Build();
                configurationBuilder.AddConfiguration(integracionBuilder);
            });
        }
    }
}
