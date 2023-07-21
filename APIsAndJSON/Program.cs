using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Ron and Ye
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(RonVSKanyeAPI.GetRonVoice());
                Console.WriteLine(RonVSKanyeAPI.GetYeVoice());
            }
    
            //Weather
            string city = "Pittsburgh";
            
            Console.WriteLine("--------------------------");
            Console.WriteLine($"The city of {city} has the following weather information:");
            Console.WriteLine(OpenWeatherMapAPI.DescriptionGet(city));
            Console.WriteLine(OpenWeatherMapAPI.TempGet(city));
            Console.WriteLine(OpenWeatherMapAPI.PressureGet(city));
            Console.WriteLine("--------------------------");
        }
    }
}
