public interface Subject
{
    void registerObserver(Observer o);
    void removeObserver(Observer o);
    void notifyObservers();
}

public class WeatherData : Subject 
{
    private List<Observer> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherData() {
        observers = new List<Observer>();
    }

    //implement subject interface
    public void registerObserver(Observer o) {
        observers.Add(o);
    }

    public void removeObserver(Observer o) {
        int i = observers.IndexOf(o);
        if (i >= 0) {
            observers.RemoveAt(i);
        }
    }

    public void notifyObservers() {
        foreach (Observer observer in observers) {
            observer.update(temperature, humidity, pressure);
        }
    }

    //This somehow gets called when the measurements changed
    public void measurementsChanged() {
        notifyObservers();
    }

    public void setMeasurements(float temperature, float humidity, float pressure) {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        measurementsChanged();
    }

}