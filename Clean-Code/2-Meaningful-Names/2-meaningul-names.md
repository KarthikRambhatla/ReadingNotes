# Introduction
We name a lot of things day-in and day-out. So we should be good at it. Here are some things to keep in mind while naming
* Use intention-revealing names:
 
        Name of a variable, function, class (etc..) should answer why it exists, what it does and how it is used. 
        - 'd' -> daysSinceCreation
* Avoid Disinformation

        Avoid leaving false clues.
        - hp, aix, sco are unix platform variants, if you use hp for hypotenus it might confuse
        - accountList - only use if it is actually a list, else "accounts" is better
        - Long Names that vary small like XYZControllerForEfficientHandlingOfStrings
        XYZControllerForEfficientStorageOfStrings
        - spell similar concepts similarly - so developer will pick that mostly, they probably don't read comments, code. 
        - using lower case l and upper cas O as variable names
* Make Meaningful Distinctions

        Do not solely write to satisfy compiler
        - To use same name, misspelling or adding numbers
        -Noise words like Info, Data. You have a class product, productinfo, ProductData.Naming a variable a 'variable', naming a table 'XYZtable'. We do not know the difference between Customer and CustomerObject, unless you have specific conventions

* Use Pronouncable Names

        Programming is a social activity. If the names are not pronouncable it will be difficult to discuss.
        - genymdhms - generationTimeStamp
* Use Searchable Names

        Avoid single letters and numeric constants. It is easy to search for WORK_DAYS_PER_WEEK instead of 5. similarly naming something e is terrible. Ofcourse, we can use single variable names that are just in local methods and i, j in loops.
* Avoid Encodings - Unnecessary burden to learn that
        
        Do not use Hungarian notation, prefixes like 'm' for member variables, 'I' for interfaces. It is redundant information. Use proper naming conventions and tools to find out the type.
        - I think it is convention in C# to use I for interfaces and that stays like that for now at least

* Avoid Mental Mapping

        Readers should not have to mentally translate the names to something they already know

* Class Names

        Should be Noun or Noun Phrase. Not verb
        - Customer Account AddressParser are correct
        - Avoid words like Manager, Processor, Data or Info in the name of a class
* Method Names

        Should have Verb or Verb Phrase
        - postPayment, deletePage
        - Accessors - get, mutators - set, predicates - is
        - When constructors are overloaded, use the arguments like Complex.FromRealNumber() instead of just "new complex()", enforce it by making respective constructor private

* Don't be Cute

        Say what you actually mean. Mean what you say
        - Don't use HolyHandGrenade() for DeleteItems()
        - using Whack() instead of kill(), 
        - Culture dependent jokes like eatMyShorts() for abort()

* Pick One Word per Concept
        
        choose one word from abstract concept and stick with it
        - Confusing to have fetch, retrieve, get. How do they differ?
        - Controller, Manager and driver. What is difference between DeviceManager and Protocol Controller. Why are both not controllers or Managers. Its hard to know in what sense they differ

* Don't Pun

        Suppose we have add method for concatenating existing values. This add name should not be used to insert into collection. Instead we should call "insert" or "append". We want readers to understand in quick skim.
* Use Solution Domain Names

        Instead of using problem domain names, use solution domain. Use CS terms, algorithms, pattern, math terms. Because when future devs read this, we don't want them to run back and forth to customer or business. They will know AccountVisitor - Visitor Pattern, JobQueue. Technical names

* Use Problem Domain Names

        The code that has more to do with problem domain concepts should have names drawn from problem domain. So programmer who maintains the code can ask a domain expert.
* Add Meaningful Context

        If we find state variable alone it is tough to make sense, adding addr will give reader some context. addrState - State belongs to Address. It is better to create Class and keep variable there, so it will have a context

* Don't Add Gratuitous Context

        Add no more context than necessary. Unnecessarily adding application name, module name at the start like GSDAccountAddress having GSD - Gas Station Deluxe app name 

# Final Words

    Do not be afraid of renaming things for the fear that some other developers will object. You will probably end up surprising someone but do not let it stop.
           



