public interface Observer
{
    void update(float temp, float humidity, float pressure);
}

public interface DisplayElement
{
    void display();
}

public class CurrentConditions : Observer, DisplayElement
{
    private float temperature;
    private float humidity;
    private Subject weatherData;

    public CurrentConditions(Subject weatherData) {
        this.weatherData = weatherData;
        weatherData.registerObserver(this);
    }

    public void update(float temperature, float humidity, float pressure) {
        this.temperature = temperature;
        this.humidity = humidity;
        display();
    }

    public void display() {
        Console.WriteLine("Current conditions: " + temperature 
            + "F degrees and " + humidity + "% humidity");
    }
}

public class StatisticsDisplay : Observer, DisplayElement
{
    private float maxTemp = 0.0f;
    private float minTemp = 200;
    private float tempSum= 0.0f;
    private int numReadings;
    private Subject weatherData;

    public StatisticsDisplay(Subject weatherData) {
        this.weatherData = weatherData;
        weatherData.registerObserver(this);
    }

    public void update(float temperature, float humidity, float pressure) {
        tempSum += temperature;
        numReadings++;

        if (temperature > maxTemp) {
            maxTemp = temperature;
        }
 
        if (temperature < minTemp) {
            minTemp = temperature;
        }

        display();
    }

    public void display() {
        Console.WriteLine("Avg/Max/Min temperature = " + (tempSum / numReadings)
            + "/" + maxTemp + "/" + minTemp);
    }
}

public class ForecastDisplay : Observer, DisplayElement
{
    private float currentPressure = 29.92f;  
    private float lastPressure;
    private Subject weatherData;

    public ForecastDisplay(Subject weatherData) {
        this.weatherData = weatherData;
        weatherData.registerObserver(this);
    }

    public void update(float temperature, float humidity, float pressure) {
        lastPressure = currentPressure;
        currentPressure = pressure;

        display();
    }

    public void display() {
        Console.Write("Forecast: ");
        if (currentPressure > lastPressure) {
            Console.WriteLine("Improving weather on the way!");
        } else if (currentPressure == lastPressure) {
            Console.WriteLine("More of the same");
        } else if (currentPressure < lastPressure) {
            Console.WriteLine("Watch out for cooler, rainy weather");
        }
    }
}