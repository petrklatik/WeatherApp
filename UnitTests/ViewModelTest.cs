using WeatherApp.ViewModel;

namespace UnitTests
{
    [TestClass]
    public class WeatherViewModelTests
    {
        private WeatherViewModel _weatherViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _weatherViewModel = new WeatherViewModel();
        }

        [TestMethod]
        public async Task TestSearchCommand_Valid()
        {
            // Arrange
            _weatherViewModel.SearchText = "Prague";

            // Act
            _weatherViewModel.SearchCommand.Execute(null);

            // Simulate API call delay
            await Task.Delay(1000);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(_weatherViewModel.WeatherData));
            Assert.IsTrue(string.IsNullOrEmpty(_weatherViewModel.ErrorMessage));
        }

        [TestMethod]
        public async Task TestSearchCommand_Invalid()
        {
            // Arrange
            _weatherViewModel.SearchText = "InvalidCityName";

            // Act
            _weatherViewModel.SearchCommand.Execute(null);

            // Simulate API call delay
            await Task.Delay(1000);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(_weatherViewModel.ErrorMessage));
        }

        [TestMethod]
        public void TestClearCommand()
        {
            // Arrange
            _weatherViewModel.SearchText = "Prague";
            _weatherViewModel.WeatherData = "Some weather data";

            // Act
            _weatherViewModel.ClearCommand.Execute(null);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(_weatherViewModel.SearchText));
            Assert.IsTrue(string.IsNullOrEmpty(_weatherViewModel.WeatherData));
            Assert.IsTrue(string.IsNullOrEmpty(_weatherViewModel.ErrorMessage));
        }
    }
}