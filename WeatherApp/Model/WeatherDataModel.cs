using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class WeatherDataModel
    {
        public string PlaceName { get; set; }
        public CurrentWeather currentWeather { get; set; }
        public List<TodaysWeather> todaysWeather { get; set; } 
        public List<DailyWeather> dailyWeather { get; set; }
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
