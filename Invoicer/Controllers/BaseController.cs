using System;

namespace Invoicer.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseController: Controller
    {
        public BaseController(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
            this.DbContext = serviceProvider.GetService<ApplicationDbContext>();
        }

        public ApplicationDbContext DbContext { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
    }
}
