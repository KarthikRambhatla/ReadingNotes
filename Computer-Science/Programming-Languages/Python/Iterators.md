An Iterator is an underlying Python object that allows you to traverse through a collect (list, tuple, dictionary) on element at a time. In fact, generators a special, simplified type of iterators.

Everytime you use a `for` loop, iterators are working silently behind the scenes.

### The Iteration Protocol: `__iter__()` and `__next__()`

For an object to be an iterator, it must implement two special methods.
- `__iter__()`: Initializes or returns the iterator object itself
- `__next__()`: Returns next item in sequence, if none left raises `StopIteration` exception to signal that loop should end.

### Iterable vs Iterator

- Iterable - Anything you can loop over. It is not iterator but has ` __iter__()` to create one.

- Iterator - Actual agent that keeps track of current position during loop and serves data via `__next__()`

* You can convert any iterable into an iterator using python's built-in `iter()` function

```Python
fruits = ["apple","banana"]

fruit_iterator = iter(fruits)

print(next(fruit_iterator))
```

### What a `for` loop actually does

when we write a `for` loop, it is clean and readable. Python translates the `for` loop into a `while` loop that uses iterator

```Python
for item in [1,2]:
    print(item)
```


```Python
range_iterator = iter([1,2])
while True:
    try:
        item = next(range_iterator)
        print(item)
    except StopIteration:
        break
```

### Building Custom Iterator:

For any Python class, implementing `__iter__()` and `__next__()` will make it an iterator. You can have complete control over how data is traversed.

```Python
class CountDown:
    def __init__(self, start):
        self.current = start
    
    def __iter__(self):
        return self
    
    def __next__(self):
        if self.current <= 0:
            raise StopIteration
        
        data = self.current
        self.current -= 1
        return data

# using the custom iterator
counter = CountDown(3)
for num in counter:
    print(num)
```