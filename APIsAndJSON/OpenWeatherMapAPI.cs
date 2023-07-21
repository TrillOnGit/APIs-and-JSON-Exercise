using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        //Weather Project

        public static JToken? WeatherAPICall(string field, string cityName)
        {
            var client = new HttpClient();
            
            var weatherKey = JObject.Parse(File.ReadAllText("appsettings.json")).GetValue("DefaultKey")?.ToString();
            var weatherURL =
                $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={weatherKey}&units=imperial";
            var openWeatherCall = client.GetStringAsync(weatherURL).Result;

            return JObject.Parse(openWeatherCall).GetValue(field);
        }
        
        public static string TempGet(string cityName)
        {
            var weatherBase = WeatherAPICall("main", cityName);
            var weatherTempF = Math.Round(weatherBase.Value<double>("temp"), 2);

            return $"{weatherTempF.ToString(CultureInfo.CurrentCulture)} degrees Fahrenheit.";
        }
        
        public static string PressureGet(string cityName)
        {
            var weatherBase = WeatherAPICall("main", cityName);
            var weatherPressureF = Math.Round(weatherBase.Value<double>("pressure"), 2);
            
            return $"{weatherPressureF.ToString(CultureInfo.CurrentCulture)} points of pressure.";
        }
        
        public static string DescriptionGet(string cityName)
        {
            var weatherBase = WeatherAPICall("weather", cityName);
            var weatherDesc = weatherBase[0].Value<string>("description");
            //Console.WriteLine(weatherDesc);
            return $"The forecast is {weatherDesc}.";
        }
    }
}
