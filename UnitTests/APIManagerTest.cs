using WeatherApp.Model;

namespace UnitTests
{
    [TestClass]
    public class APIManagerTests
    {
        private APIManager _apiManager;

        [TestInitialize]
        public void TestInitialize()
        {
            //Instantiate the APIManager class
            _apiManager = new APIManager();
        }

        [TestMethod]
        public async Task GetLocationAsync_ReturnsLocation()
        {
            // Arrange
            var cityName = "Prague";

            // Act
            var location = await _apiManager.GetLocationAsync(cityName);

            // Assert
            Assert.IsNotNull(location);
            Assert.AreEqual(cityName, location.Name);
            Assert.IsTrue(location.Latitude >= -90 && location.Latitude <= 90);
            Assert.IsTrue(location.Longitude >= -180 && location.Longitude <= 180);
        }

        [TestMethod]
        public async Task GetWeatherDataAsync_ReturnsWeatherData()
        {
            // Arrange
            var location = new LocationModel
            {
                Name = "Prague",
                Latitude = 50.0755,
                Longitude = 14.4378
            };

            // Act
            var weatherData = await _apiManager.GetWeatherDataAsync(location);

            // Assert
            Assert.IsNotNull(weatherData);
            Assert.AreEqual(location.Name, weatherData.PlaceName);
            Assert.IsNotNull(weatherData.CurrentWeather);
            Assert.IsNotNull(weatherData.TodaysWeather);
            Assert.IsNotNull(weatherData.DailyWeather);
        }
    }
}