Pythonic way of writing concisely to create collections from existing iterables in single line of code. Makes code cleaner, shorter and often faster.

### List Comprehension

[expression **for** item **in** iterable **if** condition]

```python
squares = [x ** 2 for x in range(5)]

```

### Dictionary Comprehension

```python
square_dict={x: x**2 for x in range(3)}
```

### Set Comprehension
Automatically remove duplicates and unordered

```
words = ["apple","banana","kiwi","pear","apple"]
lengths = {len(w) for w in words}
```

### Generator Expressions
use () to create a generator - instead of loading entire collection into memory at once, processes one by one on demand. Great for massive datasets.

```python
large_gen = (x*2 for x in range(100000))
```

### Adding logic (Filtering & Conditioning)

- Filtering with if at the end: 
```python
evens = [x for x in range(10) if x % 2 == 0]
```

- Transform with if-else at the beginning
```python
labels = ["Even" if x % 2 == 0 else "Odd" for x in range(10)]
```