namespace Invoicer.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Models.DbModels;

    public static class DbContextExtensions
    {
        public static InvoiceDbContext Initialize(this InvoiceDbContext context, IServiceProvider provider)
        {
            if (context.Distributors.Any())
            {
                return context;
            }

           // TODO Sensitive data
           

            return context;
        }
    }
}
