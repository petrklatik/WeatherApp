using System;
using System.Collections.Generic;

namespace WeatherApp.Model
{
    public class WeatherDataModel
    {
        public string PlaceName { get; set; }
        public CurrentWeather CurrentWeather { get; set; }
        public List<TodaysWeather> TodaysWeather { get; set; }
        public List<DailyWeather> DailyWeather { get; set; }
    }

    public class CurrentWeather
    {
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public string WeatherDescription { get; set; }
        public float WindSpeed { get; set; }
    }

    public class TodaysWeather
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public string WeatherDescription { get; set; }
    }

    public class DailyWeather
    {
        public DateTime Date { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public string WeatherDescription { get; set; }
    }
}
