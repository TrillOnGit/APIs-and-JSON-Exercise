using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        
        public static async Task<string> GetRonVoice()
        {
            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = await client.GetStringAsync(ronURL);
            
            var ronParsed = ronResponse.Replace('[', ' ').Replace(']', ' ').Replace("\"", "").Trim();

            return ronParsed;
        }

        public static async Task<string?> GetYeVoice()
        {
            var client = new HttpClient();
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "mySuperSecretApiKey");
            
            var kanyeURL = "https://api.kanye.rest";
            var yeResponse = await client.GetStringAsync(kanyeURL);

            var yeParsed = JObject.Parse(yeResponse).GetValue("quote")?.ToString();

            return yeParsed;
        }
    }
}
