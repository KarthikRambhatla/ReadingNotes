Weather-O-Rama
--------------

We have a Weather station, that has physical sensors like Humidity, Temperature and Pressure - These sensor devices give the data. There is a `WeatherData` object that knows how to talk to WeatherStation and pull data. 

Our goal is to design/create an application that uses the `WeatherData` object to update 3 displays - current condition, weather stat and forecast.

`WeatherData` has getter methods `getTemperature()`, `getHumidity()` and `getPressure()`. We do not care how the actual implementation is there, we just know that `WeatherData` object can get those.

`WeatherData` also has a method `measurementsChanged()`. This method gets called whenever measurements changed. Our job is to implement this method. So that whenever measurements changed, displays gets the updated measurements
