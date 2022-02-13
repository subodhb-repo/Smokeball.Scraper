using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataProcessor = Smokeball.Scraper.Application.DataProcessor;
using Smokeball.Scraper.Application.SyncDataServices.Http;
using MediatR;
using System.Reflection;
using Smokeball.Scraper.Application;

namespace Smokeball.Scraper.Presentation.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration) =>
            services
            .AddGoogleHttpClient(configuration);

        public static IServiceCollection RegisterService(this IServiceCollection services) =>
            services
            .AddSingleton<MainWindow>()
            .AddMediatR(Assembly.GetExecutingAssembly(), typeof(Resolver).GetTypeInfo().Assembly)
            .AddTransient<DataProcessor.IScraper, DataProcessor.Scraper>();
                
        private static IServiceCollection AddGoogleHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var googleConfig = configuration.GetSection("Google");
            services
                .AddHttpClient<IGoogleHttpClient, GoogleHttpClient>(client =>
                {
                    var options = googleConfig.Get<GoogleClientOptions>();
                    client.BaseAddress = new Uri(options.BaseUrl);
                });
            return services;
        }            
    }
}
