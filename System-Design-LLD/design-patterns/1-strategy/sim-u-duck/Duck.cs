public abstract class Duck
{
    public FlyBehavior flyBehavior;
    public QuackBehavior quackBehavior;

    public Duck()
    {
    }

    //All ducks will have their own display method
    public abstract void display();

    public void performFly()
    {
        flyBehavior.fly();
    }

    public void performQuack()
    {
        quackBehavior.quack();
    }

    public void swim()
    {
        // All ducks swim in the same way, may be just in our game
    }

    //we can change the behavior dynamically
    public void setFlyBehavior(FlyBehavior fb)
    {
        flyBehavior = fb;
    }

    public void setQuackBehavior(QuackBehavior qb)
    {
        quackBehavior = qb;
    }
}



