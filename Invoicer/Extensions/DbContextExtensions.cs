namespace Invoicer.Extensions
{
    using System;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Models.DbModels;
    using Services;

    public static class DbContextExtensions
    {
        public static InvoiceDbContext Initialize(this InvoiceDbContext context, IServiceProvider provider)
        {
            var seeder = provider.GetService<ISeedService>();
            var userManager = provider.GetService<UserManager<User>>();
            seeder.Seed(context, userManager);

            return context;
        }
    }
}
