using System.Text.Json.Nodes;
using DotNetEnv;
using Newtonsoft.Json.Linq;
using DotNetEnv;
namespace APIsAndJSON
{ 
    public class Program
    {
        static async Task Main(string[] args)
        { 
            //EXERCISE 1: RON AND KANYE APP.
            for (int i = 0; i < 6; i++)
            { 
                RonVSKanyeAPI.KanyeQuote();
                Console.WriteLine("-----------------\n-----------------");
                RonVSKanyeAPI.RonQuote();
            }

            //EXERCICE 2: WEATHER APP.
            Env.TraversePath().Load();

            string apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("ERROR: OPENWEATHER_API_KEY not found!");
                Console.WriteLine("Debug info:");
                Console.WriteLine($"  Current directory: {Environment.CurrentDirectory}");
                Console.WriteLine("  Make sure .env exists in project root with exact line:");
                Console.WriteLine("  OPENWEATHER_API_KEY=your-real-key-here");
                Console.WriteLine("  (no quotes, no spaces around =)");
                return;
            }
            
            Console.WriteLine("Please what is your city name :");
            string cityName = Console.ReadLine();
            Console.WriteLine("Please enter the country code : ");
            string countryCode = Console.ReadLine().ToUpper();
            string apiCall =
                $"https://api.openweathermap.org/data/2.5/weather?q={cityName},{countryCode}&appid={apiKey}&units=imperial";
            
            await OpenWeatherMapAPI.WhatIsTheWeather(apiCall);
          
        }
    }
}
