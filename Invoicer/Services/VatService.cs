namespace Invoicer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    using Models.DbModels;
    using Models.DocModels;

    public class VatService
    {
        public async Task<Client> GetClient(string vat)
        {
            var stateNumber = string.Join("", vat.Take(2));
            var vatNumber = string.Join("", vat.Skip(2));

            string html = await this.GetInformationHtml(stateNumber, vatNumber);
            var client = this.GetClient(html, vat);

            return client;
        }

        private async Task<string> GetInformationHtml(string stateNumber, string vatNumber)
        {
            using (var httpClient = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("memberStateCode", stateNumber),
                    new KeyValuePair<string, string>("number", vatNumber),
                });

                var response = await httpClient.PostAsync("http://ec.europa.eu/taxation_customs/vies/vatResponse.html", formContent);
                var html = await response.Content.ReadAsStringAsync();
                return html;
            }
        }

        private Client GetClient(string html, string vat)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var table = doc.GetElementbyId("vatResponseFormTable");
            var rows = table.Descendants("tr");

            var validationSpan = rows.First().Descendants("span").First();
            var isValid = validationSpan.InnerText.Contains("Yes, valid VAT number");

            string GetValue(string lableName)
            {
                var row = rows.First(r => r.Descendants("td").Any(t => t.InnerText == lableName));
                var value = row.Descendants("td").Skip(1).First().InnerHtml.Replace("\r\n", "").Trim();
                return value;
            }

            var client = new Client
            {
                Vat = vat,
                EnterManualy = !isValid,
                RequestDate = Convert.ToDateTime(GetValue("Date when request received"))
            };

            if (isValid)
            {
                client.Name = new List<Name>(){new Name(){Data = GetValue("Name") } };
                client.Address = GetValue("Address")
                    .Split("<br>", StringSplitOptions.RemoveEmptyEntries)
                    .Select(d => new Address() { Data = d })
                    .ToList();
                client.ConsultationNumber = GetValue("Consultation Number");
            }

            return client;
        }
    }
}
