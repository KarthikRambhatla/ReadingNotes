
public interface QuackBehavior
{
    void quack();
}


public class Quack : QuackBehavior
{
    public void quack()
    {
        Console.WriteLine("Quack");
    }
}

public class Squeak : QuackBehavior
{
    public void quack()
    {
        Console.WriteLine("Squeak");
    }
}

public class Mute : QuackBehavior
{
    public void quack()
    {
        // do nothing, can't quack
    }
}