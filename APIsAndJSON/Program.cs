using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace APIsAndJSON
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //Ron and Ye
            for (int i = 0; i < 5; i++)
            {
                var ronRequest = RonVSKanyeAPI.GetRonVoice();
                var yeRequest = RonVSKanyeAPI.GetYeVoice();
                Console.WriteLine(await ronRequest);
                Console.WriteLine(await yeRequest);
            }
    
            //Weather
            string city = "Delmont";
            
            Console.WriteLine("--------------------------");
            Console.WriteLine($"The city of {city} has the following weather information:");
            var cityDesc = OpenWeatherMapApi.DescriptionGet(city);
            var cityTemp = OpenWeatherMapApi.TempGet(city);
            var cityPress = OpenWeatherMapApi.PressureGet(city);
            
            Console.WriteLine(await cityDesc);
            Console.WriteLine(await cityTemp);
            Console.WriteLine(await cityPress);
            Console.WriteLine("--------------------------");
        }
    }
}
