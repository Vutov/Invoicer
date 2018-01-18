namespace Invoicer.Services
{
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Models.DbModels;

    public partial class SeedService
    {
        public void Seed(InvoiceDbContext context, UserManager<User> userManager)
        {
            // TODO Working?
            User user = new User();
            user.UserName = "Admin@admin";
            user.Email = "Admin@admin";

            IdentityResult result = userManager.CreateAsync(user, "Zaq123$").Result;

            this.SeedData(context, userManager);
            context.SaveChanges();
        }

        /// <summary>
        /// Seed sensitive data, not present in Git.
        /// </summary>
        partial void SeedData(InvoiceDbContext context, UserManager<User> userManager);
    }
}
