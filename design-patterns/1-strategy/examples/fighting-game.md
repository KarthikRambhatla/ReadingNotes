character-- King, Queen, Knight, Troll, all can `fight()` in their own way. But they can have different weapons like sword or bow-and-arrow or fist.

Now, we can have a base class `Character` and all the characters inherit from it. Each character overrides the `fight()` method to provide their own implementation.

The changing thing is weapon. So we enccapsulate it.

 `Character` `HAS-A` `WeaponBehavior`

 And we will implement a set of classes : `KnifeBehavior`, `SwordBehavior`, `BowAndArrowBehavior`

 `WeaponBehavior` will have method `useWeapon()`, which will be implemented by all those specific weapons. We just `set` a particular weapon (could also be at runtime) to that specific `Character` say like `King` 
