Newspaper subscription:

A Newspaper publisher will publish newspapers. Whoever wants to get the newspaper creates a subscription. Whenever there is a new edition, that will be distributed to the subscribers. If someone does not want the paper, they unsubscribe.

This is observer pattern.

* Publisher - Subject
* Subscribers - Observers

Subject manages some data. Whenever data changes, it communicates to observers. Observers can register/subscribe or unsubscribe any time they want.

`Subject` is an interface that has `registerObserver()`, `removeObserver()` and `notifyObserver()` methods. Each `Subject` can have many `Observer`s. All `Observer`s implement `update()`

`ConcreteSubject` implements `Subject` and will also have its own getter and setter methods to manage data.

`ConcreteObserver`s implements `Observer` and will have their own methods using that data.

## OO Principle:


        Strive for loosely coupled designs between objects that interact. 

Loosely coupled objects have little knowledge about each other.

Here, the subject only knows that observer implements an update method. We will not need to modify subject to add a new observer. Changes to subject or Observer are independent.

