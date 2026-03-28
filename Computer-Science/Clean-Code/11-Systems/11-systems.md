## How would you build a city?

One cannot manage all the details of the city. Yet they work, because cities have teams of people managing parts of it. Like the water systems, power systems, traffic, law enforcement etc. Some responsible for big picture, others work on details.

Even without understanding all the details, individuals and components manage to work because they evolved to have a appropriate level of abstraction and modularity.

Clean code helps us achieve abstractions at lower level. Let us see how to do it at system level.

## Separate constructing a system from using it

Similar to constructing a building and operating a building, software systems should also separate creating app and its runtime logic.

Separate the startup process from runtime logic. Startup process - application objects are constructed, dependencies wired together. So that we will have clear *Separation of Concerns*

```
public Service getService() 
{
    if (service == null)
    {
        service = new MyService(...);
    }
    return service
}
```

In the above code, we are using *Lazy Initialization*, so until we actually need, we are not constructing MyService()

Problems with this are 
- Hard-coded dependency on MyServive, we need to create objects MyService needs
- Testing is hard. We need to mock this object, and test when it is null, not null apart from the runtime logic. Breaks `Single Responsibility Principle`
- MyService might not be always the right object, we need a global context to determine the right object. 
- Setup strategy is scattered across the application - no modularity, code duplication.

We should modularize the process of constructing objects, wiring dependencies and separate it from run time logic. And make sure to have a global, consistent strategy for resolving major dependencies.

### Separation of Main

One solution is to move all aspects of construction to main or modules called by main, and design the rest of application assuming that it has right dependencies.

    main --> Builder --> Configured Objects
    main --> application --> uses configured Objects

- flow of control is easy ot follow
- app has no knowledge of main, just expects everything already built.

### Factories

