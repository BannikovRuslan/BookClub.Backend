using BookClub.Persistence;
using ICSSoft.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace BookClub.WebApi
{
    public class Program
    {
        private static readonly IUnityContainer Container = UnityFactory.GetContainer();
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<BookClubDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception) 
                {
                    Console.WriteLine(exception);
                }
            }
            host.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        /// <summary>
        /// Создать инициализатор приложения.
        /// </summary>
        /// <param name="args">Аргументы запуска.</param>
        /// <returns>Инициализатор приложения.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(Container)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
