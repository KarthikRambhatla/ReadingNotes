For our Sim-U-Duck App, `Duck` class should have `FlyBehavior` and `QuackBehavior`. And we will have a set of classes implementing those behaviors like `FlyWithWings`, `FlyNoWay`. Similarly `Quack`, `Squeak` and `Mute` inherits `QuackBehavior`. 

Now with this 
- we solved the problem of duplicating the code 
- we will be able to change behaviors
- we will have all those behaviors in a consistent way across ducks

