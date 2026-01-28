using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task WhatIsTheWeather(string apiCall)
        {
            var response = await client.GetAsync(apiCall);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error! Status code: " + response.StatusCode);
                return;
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(jsonString);
            
            if (data.cod != 200)
            {
                Console.WriteLine($"OpenWeatherMap error: {data.message ?? "Unknown error"} (code: {data.cod})");
                return;
            }
            Console.WriteLine($"🌤️ Current Weather in {data.name}, {data.sys.country}");
            Console.WriteLine($"   Temp:       {data.main.temp:F1}°F");
            Console.WriteLine($"   Feels like: {data.main.feels_like:F1}°F");
            Console.WriteLine($"   Condition:  {data.weather[0].description} ({data.weather[0].main})");
            Console.WriteLine($"   Humidity:   {data.main.humidity}%");
            Console.WriteLine($"   Wind:       {data.wind.speed:F1} mph from {data.wind.deg}°");
            
            long unixTimestamp = (long)data.dt;
            Console.WriteLine($"   Updated:    {DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).ToLocalTime():yyyy-MM-dd HH:mm}");
        }
    }
}
