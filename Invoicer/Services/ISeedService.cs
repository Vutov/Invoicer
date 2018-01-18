namespace Invoicer.Services
{
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Models.DbModels;

    public interface ISeedService
    {
        void Seed(InvoiceDbContext context, UserManager<User> userManager);
    }
}
