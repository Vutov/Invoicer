using Microsoft.AspNetCore.Mvc;

namespace Invoicer.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models.DocModels;
    using Models.ViewModels.InvoiceViewModels;
    using Services;

    // TODO
    [Route("[Controller]")]
    public class InvoiceController : BaseController
    {
        public InvoiceController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var invoice = this.DbContext.Invoices
                .Include(d => d.Products)
                .Include(d => d.Client)
                .Include(d => d.Client.Address)
                .First();

            var model = new InvoiceViewModel()
            {
                Products = invoice.Products,
                Client = invoice.Client,
                Distributor = new Client(), // fix
                InvoiceDate = DateTime.UtcNow, // fix
                InvoiceNumber = 1, //fix
                Vat = 20, //fix
            };

            return this.View(model);
        }

        public IActionResult Create()
        {
            Stream stream = System.IO.File.Open("../xxx2.DOCX", FileMode.Open);
            // TODO DI
            var invoiceService = new InvoiceService(new VatService());
            var invoice = invoiceService.CreateInvoice(stream);
            this.DbContext.Invoices.Add(invoice);
            this.DbContext.SaveChanges();
            return this.Ok(invoice);
        }

        public IActionResult Delete()
        {
            var invoices = this.DbContext.Invoices
                .Include(d => d.Products)
                .Include(d => d.Client)
                .Include(d => d.Client.Address)
                .ToList();
            foreach (var invoice in invoices)
            {
                this.DbContext.Remove(invoice);
            }

            this.DbContext.SaveChanges();
            return this.Ok();
        }
    }
}