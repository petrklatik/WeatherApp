using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string searchText;
        private string weatherData;
        private string errorMessage;
        private APIManager apiManager;

        public WeatherViewModel()
        {
            apiManager = new APIManager();
            SearchCommand = new RelayCommand(Search);
            ClearCommand = new RelayCommand(Clear);
            ExitCommand = new RelayCommand(Exit);
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        public string WeatherData
        {
            get => weatherData;
            set
            {
                weatherData = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand ExitCommand { get; }

        private async void Search()
        {
            try
            {
                // Get location data
                LocationModel location = await apiManager.GetLocationAsync(SearchText);

                // Get weather data
                WeatherDataModel weatherData = await apiManager.GetWeatherDataAsync(location);

                // Update weather data in the view
                WeatherData = $"CURRENT WEATHER IN: {weatherData.PlaceName.ToUpper()}\n" +
                              $"Temperature: {weatherData.currentWeather.Temperature}°C\n" +
                              $"Feels Like: {weatherData.currentWeather.FeelsLike}°C\n" +
                              $"Weather Description: {weatherData.currentWeather.WeatherDescription}\n" +
                              $"Wind Speed: {weatherData.currentWeather.WindSpeed} m/s\n";

                WeatherData += $"\nWEATHER TODAY: {DateTime.Now.Date.ToString("%d/MM/yyyy")}\n\n";
                foreach (var item in weatherData.todaysWeather)
                {
                    WeatherData += $"{item.Time.ToString("HH\\:mm")} - Temperature: {item.Temperature.ToString("F2")}°C, Weather: {item.WeatherDescription}\n";
                }

                WeatherData += $"\nWEEKLY WEATHER:" +
                    $"\n\n";
                foreach (var item in weatherData.dailyWeather)
                {
                    WeatherData += $"{item.Date.ToString("dd/MM")} - Min. Temperature: {item.MinTemperature.ToString("F2")}°C | Max. Temperature: {item.MaxTemperature.ToString("F2")}°C, Weather: {item.WeatherDescription}\n";
                }

                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                // Display error message
                WeatherData = string.Empty;
                ErrorMessage = $"Something is wrong :(\n{ex.Message}\n";
                WeatherData = ErrorMessage;
            }
        }

        private void Clear()
        {
            // Clear search text and weather data
            SearchText = string.Empty;
            WeatherData = string.Empty;
            ErrorMessage = string.Empty;
        }

        private void Exit()
        {
            // Exit the app
            Application.Current.Shutdown();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}