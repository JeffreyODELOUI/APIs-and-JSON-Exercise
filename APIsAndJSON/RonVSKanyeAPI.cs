using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        static readonly HttpClient client = new HttpClient();
        public static void KanyeQuote()
        {
            var kanyeURL = "https://api.kanye.rest/";
            
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Console.WriteLine($"{kanyeQuote}");
        }

        public static void RonQuote()
        {
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine($"{ronQuote}\n");
        }
    }
}
