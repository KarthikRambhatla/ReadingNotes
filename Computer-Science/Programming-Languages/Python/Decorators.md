A Decorator is a powerful python design pattern that allows you to modify, wrap, or extend the behavior of a function or method without permanently changing its actual source code.

Like a gift wrap: it remains inside exactly the same, but wrapping paper adds extra features on outside.

### Functions - First class citizens

In python, functions are treated like variables. 
- You can assign function
- Pass function as argument to another function
- Return function from another function

```Python
def parent():
    def child():
        return "Hello from the child!"
    retrun child

func = parent()
print(func())
```
### Building a Decorator:

Decorator is a function that takes another function as argument, wraps it with code and returns the modified wrapper

- The Hard way (Behind the scenes):
```Python
def my_decorator(original_function):
    def wrapper():
        print("work before the function is called.")
        original_function()
        print("work after the function is called.")
    return wrapper

def say_hello():
    print("hello world")

say_hello = my_decorator(say_hello)
say_hello()
```

- The Pythonic way (`@` syntax)

```Python
@my_decorator
def say_hello():
    print("Hello World")

say_hello()
```

### Handling functions with arguments

Simple wrapper will crash for function with arguments. Use `*args` and `**kwargs` so decorator can accept any input parameters

```Python
def blueprint_decorator(original_function):
    def wrapper(*args, **kwargs):
        print("Logging: Executing function...")
        result = original_function(*args, **kwargs)
        print("Logging: Execution complete..")
        return result
    return wrapper

@blueprint_decorator
def add_numbers(a,b):
    return a + b

print(add_numbers(5,10))
```

### Real-World Use Cases

Highly practical and heavily used in web frameworks (Flask/Django) and data analysis

- Authorization/Permissions: Checking if a user is logged in before rendering a web page
- Logging: Keeping track of exactly when a function runs and what it outputs
- Timing/Profiling: Measuring how many ms a function takes to execute to find slow code.

```Python
import time

def timer(func):
    def wrapper(*args, **kwargs):
        start = time.time()
        res = func(*args, **kwargs)
        print(func.__name__, "took",time.time()-start,"seconds")
        return res
    return wrapper
```