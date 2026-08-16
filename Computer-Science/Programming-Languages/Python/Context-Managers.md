A Context Manager is a Python tool that automatically handles the setup and teardown of resources. It is most commonly used via the `with` statement to guarantee that resources like files, network connections, or database sessions are properly closed or released, even if code encounters an error.

### Why Context Manages Matter

without a context manager, we need to manually open and close resources

```python
file = open("data.txt", "w")
# If an error occurs here, file never closes!
file.write("Hello")
file.close()
```

To correctly handle so that file is always closed.

```python
file = open("data.txt","w")
try:
    file.write("Hello")
finally:
    file.close() #Always runs to close the file
```

With context manager, it becomes clean

```Python
with open("data.txt", "w") as file:
    file.write("Hello")
# The file automatically closes right here!
```

- python uses context managers across standard libraries. For file operations, automatically closes file descriptors. 
- Thread locks, `with threading.Lock()` safely acquires and releases thread locks
- Database connections, Automatically commits transactions on success or rolls them back on failure.

### How to Create a Context Manager

we can build context manager using two patterns.

## 1. The Class Pattern (The Protocol)

Any class that implements the `__enter__` and `__exit__` magic methods adheres to the context manager protocol.

```Python
class DatabaseConnection:
    def __enter__(self):
        print("Connecting to the database...")
        return "connection_object"
    
    def __exit__(self, exc_type, exc_val, exc_tb):
        print("Closing the database connection...")
        # returning True here would supress exception
        return False

with DatabaseConnection() as conn:
    print(f"working with {conn}")
```

## 2. The Generator Pattern (**Recommended**)

For simpler tasks, you can use the `@contextmanager` decorator from the built-in `contextlib` module.

```Python
from contextlib import contextmanager

@contextmanager
def managed_resource():
    print("Setup: Allocating resource") # Runs on __enter__
    try:
        yield "My Resource" # This value goes to the 'as' variable
    finally:
        print("Teardown: releasing resource") # Runs on __exit__

with managed_resource() as res:
    print(f"using {res}")
```