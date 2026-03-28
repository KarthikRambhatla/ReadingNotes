## OO Principles:

        Encapsulate what varies

When designing think of what parts of the code will vary often. Encapsulate them so that we can easily switch implementations, extend it. 

        Program to an interface, not to an implementation

Once we encapsulated things that vary, we program to that super type instead of specific implementation. 

Suppose we have `Dog` has a method `bark()`, `Cat` can `meow()`. Different Animals make different sounds. So `Animal` is a super type and has a method `makeSound()`. Now we need to program to `Animal` and use `makeSound()`. `Dog` and `Cat` implements the `makeSound()` and there we call specific `bark()` or `meow()`

        Favor composition over inheritance. HAS-A can be better than IS-A

Keeping in mind the above principles. First, we encapsulate the changing things, let's call those behaviors. Client `HAS-A` behavior , it could have multiple behaviors. And we just implement those behaviors in separate classes. We can easily switch because client just needs to have one of those behaviors.