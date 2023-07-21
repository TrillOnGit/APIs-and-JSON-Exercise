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
        
        public static string GetRonVoice()
        {
            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            
            var ronParsed = ronResponse.Replace('[', ' ').Replace(']', ' ').Replace("\"", "").Trim();

            return ronParsed;
        }

        public static string? GetYeVoice()
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var yeResponse = client.GetStringAsync(kanyeURL).Result;

            var yeParsed = JObject.Parse(yeResponse).GetValue("quote")?.ToString();

            return yeParsed;
        }
    }
}
