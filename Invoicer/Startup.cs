using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invoicer
{
    using Data;
    using global::AutoMapper;
    using Models.DbModels;
    using Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMemoryCache();
            services.AddDbContext<InvoiceDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<InvoiceDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddMvc();

            services.AddTransient<ISeedService, SeedService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IVatService, VatService>();
            services.AddTransient<IConverterService, ConverterService>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
