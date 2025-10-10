public interface FlyBehavior
{
    void fly();
}

public class FlyWithWings : FlyBehavior
{
    public void fly()
    {
        Console.WriteLine("I'm flying with wings");
    }
}

public class FlyNoWay : FlyBehavior
{
    public void fly()
    {
        // do nothing, can't fly
    }
}
