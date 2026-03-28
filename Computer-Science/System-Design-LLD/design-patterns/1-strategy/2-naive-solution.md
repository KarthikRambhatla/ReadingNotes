we can inherit `Duck` and override methods to not fly and squeak. 

Or, we could create an interface `flyable` and `quackable`. All the ducks now inherits `Duck` and implements these interfaces. But still the problem is same

we have to implement `fly()` and `quack()` in all these subclasses. 