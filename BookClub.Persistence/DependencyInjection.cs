using BookClub.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DefConnStr"];
            services.AddDbContext<BookClubDbContext>(options =>
            {
                //options.UseSqlite(connectionString);
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IBooksDbContext>(provider =>
                provider.GetService<BookClubDbContext>());
            services.AddScoped<ISpeakersDbContext>(provider =>
                provider.GetService<BookClubDbContext>());
            return services;
        }

    }
}
