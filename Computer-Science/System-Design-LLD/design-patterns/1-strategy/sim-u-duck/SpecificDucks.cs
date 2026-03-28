// But we want to program to an interface, not an implementation.
// so in DuckSimulator.cs we will see how we can do that.
public class MallardDuck : Duck
{
    public MallardDuck()
    {
        quackBehavior = new Quack();
        flyBehavior = new FlyWithWings();
    }

    public override void display()
    {
        Console.WriteLine("I'm a real Mallard duck");
    }
}

public class RubberDuck : Duck
{
    public RubberDuck()
    {
        quackBehavior = new Squeak();
        flyBehavior = new FlyNoWay();
    }

    public override void display()
    {
        Console.WriteLine("I'm a rubber duckie");
    }
}

public class DecoyDuck : Duck
{
    public DecoyDuck()
    {
        quackBehavior = new Mute();
        flyBehavior = new FlyNoWay();
    }

    public override void display()
    {
        Console.WriteLine("I'm a decoy duck");
    }
}