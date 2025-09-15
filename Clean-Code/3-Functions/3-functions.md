# Functions

* Small!
    
    - They should be extremely small and tell a story in an order.

* Blocks and Indenting

    - Blocks within if, else, while should be one line long and that should be another function call.
    - The overall indentation should not be more than two. That makes it readable and easy to follow

* Do One Thing
    
    - Functions should do only one thing, well.
    - We should be able to describe it as a brief TO paragraph
    
        *To RenderPageWithSetupsAndTeardowns, we check to see whether the page is a test page and if so, we include the setups and teardowns. In either case, we render the page in HTML*
     
        If we extract further it would be a restatement without abstraction. This is another way to know if it is doing more than one thing

* Sections within Functions

    - Functions having sections like declarations, initializations and sieve is a symptom that it does more than one thing

* One level of Abstraction per Function

    - Do not mix abstraction levels: 
            
            If we have a function that has very High level of abstraction like getHtml(), and intermediate level pagePathName and very low level line .append("\n"). This mixing of abstractions is always confusion whether it is essential concept or a detail.
* Reading code from Top to Bottom: The Stepdown Rule
    - Each function should be at next level of abstraction. We should be able to describe as a set of "TO Paragrahs".

            To include the setup and teardown, we include *setups* then we include content and then teardown.

            To include *setup*, we include suite setup and ...

* Switch Statements
    - Switch statements by definition does N things, so we should just bury it in a low level , in basement of an Abstract Factory - Ref [switch](switch.md)  

* Use Descriptive Names

    - choose good name for small functions that does one thing
    - Don't be afraid to make name long. A long name is better than long comment.
    - Don't be afraid to spend time choosing a name.

            Hunting for a good name might result in favourable restructuring of code
    - Be Consistent in names, use the same phrases
## Function Arguments
  
- Ideal number is nildac (0),next monadic (1), dyadic(2). Three arguments you should avoid.
- Arguments make it hard to understand. Prefer instance variables. 
- They are even hard to test all combination of arguments.
- Output arguments are even harder and need double-take because it is not natural to think of them coming out.

### Monadic Forms
- Two main reasons to pass argument to functions
    - Asking a question about the argument like fileExists("file")
    - Operating on the argument, transforming it. Like fileOpen("file"), converts it into InputStream.
- One less common reason is *event*. The program needs to interpret the function call as event and use it to alter state of system.

Apart from this, you should avoid monadic functions.

* Flag Arguments - Passing them is ugly. Function does one thing if the flag is true, does something else if the flag is false. And we cannot refactor because the caller already is sending that. Instead use different methods for it

### Dyadic Functions
- It is hard to understand. For example, writeField(name) is easier than writeField(output-stream, name). In the second we need to learn to ignore the first param, and when we ignore something, that's where bugs lie

- Ofcourse, for cartesian points accepts 2 parameters. They have a natural order
- assertEquals(expected, actual) the ordering of parameters requires practice to learn.

### Triads
    - assertEquals(message,expected,actual) we might confuse message for expected. 
    - They require double-take, but it is worth in few cases like assertEquals(1.0,amount,0.01), floats are relative thing

- Argument Object
        
     When more than 3, they are definitely a part of concept and we should create an object instead

- Argument Lists, args
- Verbs and Keywords
    - Choose good names so that explain order and intent of args. They should form a verb/Noun pair. assertExoectedEqualsActual is better than assertEquals

- Have No Side Effects
    - side effects are when function promises to do one thing but also does something hidden. 
    
            checkPassword, by the name tells that it checks password. But if it initializzes a session after chceking and before returning true. It is a side effect. Someone who thinks this only checks password, ends up erasing existing session data. If you really want this temporal couping (only called at certain times) then you must name as checkPasswordaAndIntializeSession, Ofcourse it violates do one thing principle.

- Output Arguments
    - Arguments are naturally inputs to functions, so it needs double-take to see them as output
    - In days before OO, ouput args were needed. Now, *this* is intended to act as output arg.

            Avoid Output arguments. If your function must change state of something, have it change the state of its owning object.
            use report.appendFooter() instead of appendFooter(report) 

## Command Query Separation
* Function should either do something or answer something, but not both. Either you change state or return info about object.

        public boolean set(String attribute,String value);

        if(set("username","bob"))...
    
    Is *set* setting it and returning success or failure. Or is it asking whether we previously set it

    we could rename it to setAndCheckIfExists, but the better thing is to separate command from query.

        if (attributeExists("username")){
            setAttribute("username","bob");
        }

## Prefer Exceptions to Error Codes

* Returning error code is subtle violation of command query separation. 

        if (deletePage(page) == E_OK) {
            //do something
        }
        else {
            //handle error
        }

    The problem here is not directly the verb/adjective confusion. But the caller must handler and it gives rise to chained if else conditions.

    Instead using exceptions, makes happy path code separate and simplified.

        try{
            deletePage(page);
            //do something
        }
        catch (Exception ex){
            //handle error
        }

* **Extract Try/Catch blocks** 
    
    They confuse structure, mix error processing with normal processing. It is better to extract the bodies into their own functions. In the above example, take all the code of do something into separate function and just call it there.

* **Error Handling is One thing**

    Functions should do one thing and error handling is one thing. If it handles errors, it should do nothing else. Just try-catch-finally that's all.

* **Dependency Magnet**

    When you return Error codes, it means that there is a class or enum "Error" in which all those codes are defined. These are dependency magent - many others import them and use, when "Error" changes all these needs to be recompiled and redeployed. So programmers won't change this class to add new errors and instead reuse and hence mess.

    When you use exceptions, the new ones are derivatives of Exception Class. You can add without forcing recompilation or redeployment.

## Don't Repeat Yourself - The DRY principle

    When we repeat code in different modules, when there is a modification neeeded, it needs multiple places to change. And there is a chance that we miss in one of them.

    Codd's Database normal forms - eliminate duplicaton in data
    OOPS - concentrate code in base class if redundant
    Aspect Oriented programming, Component oriented Programming, Structured Programming, etc all are strategies to eliminate duplication

* Structured Programming

    Edsger Dijkstra's rule

        Every function and blocks within functions's should have one entry and one exit. 
    
    That means no break or continue and never a goto

    But this rule is only in large functions. But if functions are small, it serves little purpose. So when functions are small, occassional return break continue does no harm and can be more expressive than single-entry, single-exit rule

## How to write Functions like this?

* writing software is like any other kind of writing. Jot down thoughts and refine it until it reads well. 

* Author's way of writing

        - writes long, complicated, indented, nested functions with long args list, arbitrary names, duplicated code.
        - But a suite of unit tests exist to test all of that.
        - Then starts to refine and ends up with satisfying all rules

## Conclusion

Every system is built from a domain-specific language designed by programmers to describe the system. 

* Functions are verbs, classes are Nouns.

The art of programming == Art of language design

Think of it as stories to be told. Use the facilities of your chosen programming language and construct a richer and expressive domain language with which you can tell the story.
