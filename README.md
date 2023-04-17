# WeatherApp

**Author: Petr Klátík**

WeatherApp is a simple weather application built in C# using the MVVM (Model-View-ViewModel) architecture, designed to display current weather information, hourly weather data until midnight, and a five-day forecast based on user input location.

## Features
- Retrieves weather data from the OpenWeatherMap API based on user input location
- Displays current weather information, including description, temperature, and other relevant data
- Provides hourly weather data until midnight, including temperature, weather description, and time
- Displays a five-day forecast with weather information for each day, including description and temperature

## Technologies Used
- C# programming language
- WPF (Windows Presentation Foundation) for the user interface
- MVVM (Model-View-ViewModel) architecture for improved organization and management of application logic and user interface interactions.
- JSON parsing for handling API response

## Getting Started
To run the WeatherApp locally, follow these steps:

1. Clone the WeatherApp repository to your local machine.
2. Open the solution in Visual Studio.
3. Build and run the solution in Visual Studio.
4. Enter a location in the provided input field and click the "Search" button.
5. The current weather information, hourly weather data until midnight, and the five-day forecast for the provided location will be displayed.

## TODO
- Implement the Model component to handle API requests and parse the JSON response.
- Develop the ViewModel component to handle the logic for updating the UI with weather data.
- Implement unit tests for the Model and ViewModel components to ensure accurate and reliable weather data retrieval.
