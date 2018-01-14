using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Invoicer.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models.ViewModels;
    using Services;

    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
        
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
