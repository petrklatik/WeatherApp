# WeatherApp

**Author: Petr Klátík**

WeatherApp is a simple weather application built in C# using the MVVM (Model-View-ViewModel) architecture, designed to display current weather information, hourly weather data until midnight, and a seven-day forecast based on user input location.

## Features
- Retrieves weather data from the OpenWeatherMap API based on user input location
- Displays current weather information, including description, temperature, and other relevant data
- Provides hourly weather data until midnight, including temperature, weather description, and time
- Displays a seven-day forecast with weather information for each day, including description and temperature

## Technologies Used
- C# programming language
- WPF (Windows Presentation Foundation) for the user interface
- MVVM (Model-View-ViewModel) architecture for improved organization and management of application logic and user interface interactions.
- JSON parsing for handling API response

## Dependencies
The app uses the following external libraries:
- Newtonsoft.Json: This library is used to deserialize JSON responses from the API calls

## How to use
To use the weather app, follow these steps:
1. Clone the repository to your local machine
2. Open the solution in Visual Studio or any other compatible IDE
3. Build the solution to restore NuGet packages and compile the code
4. Run the app to launch the weather app
5. Enter a place name in the search text box and click the search button to retrieve weather data
6. The weather data will be displayed in the app
7. Click the clear button to clear the search text and weather data
8. Click the exit button to exit the application
