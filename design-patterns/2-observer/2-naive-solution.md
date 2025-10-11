We can simply use getter methods in `measurementsChanged()` and call the update methods of each display with those variables.

``` C#
// Naive solution
public class WeatherData {

    public void measurementsChanged() {
        // use getter methods to get variables
        float temperature = getTemperature();
        float humidity = getHumidity();
        float pressure = getPressure();

        // update all displays
        currentConditionDisplay.update(temperature, humidity, pressure);
        statisticsDisplay.update(temperature, humidity, pressure);
        forecastDisplay.update(temperature, humidity, pressure);
    }
}

```