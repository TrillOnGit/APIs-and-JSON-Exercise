using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal static class OpenWeatherMapApi
    {
        //Weather Project

        private static async Task<JToken?> WeatherApiCall(string field, string cityName)
        {
            var client = new HttpClient();
            
            var weatherKey = JObject.Parse(await File.ReadAllTextAsync("appsettings.json")).GetValue("DefaultKey")?.ToString();
            var weatherUrl =
                $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={weatherKey}&units=imperial";
            var openWeatherCall = await client.GetStringAsync(weatherUrl);

            return JObject.Parse(openWeatherCall).GetValue(field);
        }
        
        public static async Task<string> TempGet(string cityName)
        {
            var weatherBase = await WeatherApiCall("main", cityName);
            var weatherTempF = Math.Round(weatherBase.Value<double>("temp"), 2);

            return $"{weatherTempF.ToString(CultureInfo.CurrentCulture)} degrees Fahrenheit.";
        }
        
        public static async Task<string> PressureGet(string cityName)
        {
            var weatherBase = await WeatherApiCall("main", cityName);
            var weatherPressureF = Math.Round(weatherBase.Value<double>("pressure"), 2);
            
            return $"{weatherPressureF.ToString(CultureInfo.CurrentCulture)} points of pressure.";
        }
        
        public static async Task<string> DescriptionGet(string cityName)
        {
            var weatherBase = await WeatherApiCall("weather", cityName);
            var weatherDesc = weatherBase[0].Value<string>("description");
            return $"The forecast is {weatherDesc}.";
        }
    }
}
