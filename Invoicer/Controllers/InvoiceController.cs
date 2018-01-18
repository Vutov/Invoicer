using Microsoft.AspNetCore.Mvc;

namespace Invoicer.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;
    using Models.ViewModels.InvoiceViewModels;
    using Services;
    using WkWrap.Core;

    // TODO
    [Route("[Controller]")]
    [Authorize]
    public class InvoiceController : BaseController
    {
        public InvoiceController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var invoice = this.DbContext.Invoices.Skip(1)
                .Include(d => d.Products)
                .Include(d => d.Client)
                .Include(d => d.Client.Name)
                .Include(d => d.Client.Address)
                .Include(d => d.Distributor)
                .Include(d => d.Distributor.Name)
                .Include(d => d.Distributor.Address)
                .Include(d => d.Distributor.Responsibles)
                .Include(d => d.Distributor.PaymentDetails)
                .First();

            var model = new InvoiceViewModel()
            {
                Products = invoice.Products,
                Client = invoice.Client,
                Distributor = invoice.Distributor, // fix
                InvoiceDate = DateTime.UtcNow, // fix
                InvoiceNumber = 1, //fix
                Vat = 20, //fix
            };

            return this.View(model);
        }

        [HttpPost]
        [Route("PDF")]
        [AutoValidateAntiforgeryToken]
        public FileResult PDF(string html)
        {
            var host = this.HttpContext.Request.Scheme + "://" + this.HttpContext.Request.Host.Value;
            var matches = Regex.Matches(html, @"href=""(\/.*)"">");
            foreach (Match match in matches)
            {
                var value = match.Groups[1].Value;
                html = html.Replace(value, host + value);
            }

            var wkhtmltopdf = new FileInfo(@"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe");
            var converter = new HtmlToPdfConverter(wkhtmltopdf);
            var settings = new ConversionSettings(
                pageSize: PageSize.A4,
                orientation: PageOrientation.Portrait,
                margins: new PageMargins(10, 5, 5, 5),
                grayscale: false,
                lowQuality: false,
                quiet: true,
                enableJavaScript: true,
                javaScriptDelay: null,
                enableExternalLinks: true,
                enableImages: true,
                executionTimeout: null);
            var pdfBytes = converter.ConvertToPdf(html, Encoding.UTF8, settings);
            string result = System.Text.Encoding.UTF8.GetString(pdfBytes);
            return File(pdfBytes, "application/pdf", "magic.pdf");
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            Stream stream = System.IO.File.Open("../xxx2.DOCX", FileMode.Open);
            // TODO DI
            var invoiceService = new InvoiceService(new VatService());
            var invoice = invoiceService.CreateInvoice(stream);
            invoice.CreatedBy = this.GetCurrentUser();
            invoice.Distributor = this.DbContext.Distributors.First();
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