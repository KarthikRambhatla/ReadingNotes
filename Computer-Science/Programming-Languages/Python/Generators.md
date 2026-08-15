Generators are special functions that produce sequence of values on demand using the `yield` keyword. They allow to produce massive amount of data one item at a time without loading entire dataset into memory.

### `Yield`

> When a standard function hits `return`, it terminates completely. 

> When a generator hits `yied` -> It pauses, saves state and gives value

```Python
def get_numbers(n):
    result=[]
    for i in range(n):
        result.append(i)
    return result
```

```Python
def get_numbers_gen(n):
    for i in range(n):
        yield i
```

### How to retrieve

Because generators produce data on fly, we can't access with indexer like get_numbers_gen[0], instead you consume them using loops or the next() function.

- Using a `for` loop:
```Python
for num in get_numbers_gen(5):
    print(num)
```

- using the `next()` function:
```Python
gen = get_numbers_gen(2)
print(next(gen))  # 0
print(next(gen))  # 1
print(next(gen))  # Raises `Stopiteration` error because data is exhausted
```

### Generator expression vs List Comprehensions

- Swap `()` for `[]` to create quick Generator expression

```Python

squares_list = [x ** 2 for x in range(1000000)] #uses lot of RAM
squares_gen = (x ** 2 for x in range(1000000)) #uses almost 0 RAM
```


### Benefits:
- Memory Effeciency: For reading Giant log files line by line
- Infinite Sequences: You can create loops that run forever without crashing system
```Python
def infinite_counter():
    num = 1
    while True:
        yield num
        num += 1
```
-  Piipelines: You can string multiple generators together to stream data smoothly

