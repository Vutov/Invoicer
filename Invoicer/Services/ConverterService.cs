namespace Invoicer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Text.RegularExpressions;

    public class ConverterService : IConverterService
    {
        public string NumberToWords(double number)
        {
            var digits = number.ToString(".00");
            digits = digits.Substring(digits.IndexOf(".") + 1);
            string words = string.Empty;
            using (var httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("action", "ajax_number_spell_words"),
                    new KeyValuePair<string, string>("number", Math.Truncate(number).ToString(CultureInfo.InvariantCulture)),
                    new KeyValuePair<string, string>("type", "0"),
                    new KeyValuePair<string, string>("locale", "bg"),
                });

                var response = httpClient.PostAsync("https://www.tools4noobs.com/", content).Result;
                var html = response.Content.ReadAsStringAsync().Result;

                words = Regex.Match(html, @">(.+)<\/div").Groups[1].Value;
            }

            return $"{words} лв. и {digits} ст.";
        }
    }
}
