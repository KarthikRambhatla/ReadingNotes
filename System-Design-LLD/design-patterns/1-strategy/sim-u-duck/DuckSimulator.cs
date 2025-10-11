public class SimUDuck {
    public static void Main(string[] args) {
        Duck mallard = new MallardDuck();
        mallard.performQuack();
        mallard.performFly();

        Duck model = new ModelDuck();
        model.performFly(); // does not fly
        model.setFlyBehavior(new FlyRocketPowered());
        model.performFly(); // now flies with rocket
    }
}

// some new Duck type
public class ModelDuck : Duck
{
    public ModelDuck()
    {
        flyBehavior = new FlyNoWay();
        quackBehavior = new Quack();
    }

    public override void display()
    {
        Console.WriteLine("I'm a model duck");
    }
}

//we have some new behavior
public class FlyRocketPowered : FlyBehavior
{
    public void fly()
    {
        Console.WriteLine("I'm flying with a rocket");
    }
}