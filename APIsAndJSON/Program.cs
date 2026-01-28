using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

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
            string apiKey = "b5feeda3d4e76a92c94d698b7dc0cf72";
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
