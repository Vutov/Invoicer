namespace Invoicer.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    using global::AutoMapper;
    using Models.DbModels;
    using Models.DocModels;

    // TODO town and MOL
    public class InvoiceService
    {
        private readonly VatService _vatService;

        public InvoiceService(VatService vatService)
        {
            _vatService = vatService;
        }

        public Invoice CreateInvoice(Stream stream)
        {
            using (WordprocessingDocument wd = WordprocessingDocument.Open(stream, false))
            {
                var document = wd.MainDocumentPart.Document;
                var vat = this.ExtractValue<Paragraph>(document, @"(?:[Vv][Aa][Tt]\s*:\s*)(.+)\s?", "vat:");
                var vatTask = _vatService.GetClient(vat);

                var invoice = new Invoice();
                var docProducts = this.GetTableValues<DocProduct>(document).ToList();
                var products = Mapper.Map<IEnumerable<DocProduct>, IEnumerable<Product>>(docProducts);
              
                invoice.Products = products.ToList();
                var weightRegex = @"(?:(?:[Тт][Ее][Гг][Лл][Оо])|(?:[Ww][Ee][Ii][Gg][Hh][Tt]))\s*:\s*(.+)\s?";
                invoice.Weight = this.ExtractValue<Paragraph>(document, weightRegex, "weight:", "тегло:");

                var invoiceCell = document.Descendants<TableCell>()
                    .First(d => d.Descendants<Paragraph>().Any(c => c.InnerText.Contains("INVOICE")))
                    .TakeLast(2)
                    .ToList();
                invoice.DocumentID = Regex.Match(invoiceCell[0].InnerText, @"(\d+)").Groups[1].Value;
                invoice.DocumentDate = Convert.ToDateTime(invoiceCell[1].InnerText);
                invoice.CurrencyID = document.Descendants<TableCell>().Any(c => c.InnerText == "код")? CurrencyEnum.BGR : CurrencyEnum.EURO;
                invoice.Client = vatTask.Result;

                return invoice;
            }
        }

        private string ExtractValue<T>(Document doc, string pattern, params string[] keyWords) where T : OpenXmlElement
        {
            foreach (var keyWord in keyWords)
            {
                var cell = doc.Descendants<T>().FirstOrDefault(d => d.InnerText.ToLower().Contains(keyWord));
                if (cell != null)
                {
                    var value = Regex.Match(cell.InnerText, pattern).Groups[1].Value;
                    return value;
                }
            }

            return string.Empty;
        }
        
        private IEnumerable<T> GetTableValues<T>(Document document)
        {
            var productsTable = document.Descendants<Table>()
                    .Single(t =>
                    {
                        var trs = t.Descendants<TableRow>();
                        if (!trs.Any())
                        {
                            return false;
                        }

                        var header = trs.First();
                        return header.Descendants<TableCell>().Count() == typeof(T).GetProperties().Count();
                    });

            var rows = productsTable.Descendants<TableRow>().Skip(1); // first is the header
            var items = new List<T>();
            foreach (var row in rows)
            {
                var cells = row.Descendants<TableCell>().ToList();
                var item = Activator.CreateInstance<T>();
                var props = typeof(T).GetProperties(); // TODO order by place attr
                for (int i = 0; i < cells.Count(); i++)
                {
                    var propInfo = props[i];
                    var value = Convert.ChangeType(cells[i].InnerText, propInfo.PropertyType);
                    propInfo.SetValue(item, value, null);
                }

                items.Add(item);
            }

            return items;
        }
    }
}
