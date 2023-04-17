using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class APIManager
    {
        private const string GoogleGeocodeAPIKey = "AIzaSyDbU4AotPVv5j3VW25YlgiPp0AIityRm2Q";
        private const string OpenWeatherMapAPIKey = "e6912490e60547ad0c8fbd6c1b1af2c5";

        private const string GoogleGeocodeAPIURL = "https://maps.googleapis.com/maps/api/geocode/json";
        private const string OpenWeatherMapAPIURL = "https://api.openweathermap.org/data/3.0/onecall";

        public async Task<LocationModel> GetLocationAsync(string cityName)
        {
            // Call the Google Geocode API to get the location data for the given location name
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{GoogleGeocodeAPIURL}?address={cityName}&key={GoogleGeocodeAPIKey}");
            var json = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(json);

            if (data.status == "OK")
            {
                // Parse the response data and create a new LocationModel
                var location = new LocationModel
                {
                    Name = data.results[0].address_components[0].long_name,
                    Latitude = data.results[0].geometry.location.lat,
                    Longitude = data.results[0].geometry.location.lng
                };
                return location;
            }
            else
            {
                throw new Exception("Unable to get location data.");
            }
        }

        public async Task<WeatherDataModel> GetWeatherDataAsync(LocationModel location)
        {
            // Call the OpenWeatherMap API to get the weather data for the given location
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{OpenWeatherMapAPIURL}?lat={location.Latitude}&lon={location.Longitude}&exclude=minutely,alerts&appid={OpenWeatherMapAPIKey}&units=metric");
            var json = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(json);

            if (data != null)
            {
                // Parse the response data and create a new WeatherDataModel
                var weatherData = new WeatherDataModel
                {
                    PlaceName = location.Name,
                    CurrentWeather = new CurrentWeather
                    {
                        Temperature = data.current.temp,
                        FeelsLike = data.current.feels_like,
                        WeatherDescription = data.current.weather[0].description,
                        WindSpeed = data.current.wind_speed
                    },
                    TodaysWeather = new List<TodaysWeather>(),
                    DailyWeather = new List<DailyWeather>()
                };

                // Parse the hourly weather data for today
                var today = DateTime.Now.Date;
                foreach (var item in data.hourly)
                {
                    var time = DateTimeOffset.FromUnixTimeSeconds((long)item.dt).LocalDateTime;
                    if (time.Date == today)
                    {
                        weatherData.TodaysWeather.Add(new TodaysWeather
                        {
                            Time = time,
                            Temperature = item.temp,
                            WeatherDescription = item.weather[0].description
                        });
                    }
                }

                // Parse the daily weather data for the next 7 days
                var week = today.AddDays(7);
                foreach (var item in data.daily)
                {
                    var date = DateTimeOffset.FromUnixTimeSeconds((long)item.dt).LocalDateTime.Date;
                    if (date <= week)
                    {
                        weatherData.DailyWeather.Add(new DailyWeather
                        {
                            Date = date,
                            MinTemperature = item.temp.min,
                            MaxTemperature = item.temp.max,
                            WeatherDescription = item.weather[0].description
                        });
                    }
                }
                return weatherData;
            }
            else
            {
                throw new Exception("Unable to get weather data.");
            }
        }
    }
}