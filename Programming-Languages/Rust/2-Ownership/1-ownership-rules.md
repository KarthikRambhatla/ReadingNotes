Ownership is a set of rules Rust uses for memory management. These rules help to determine when to free memory. In other programming language, either we manually free the memory allocated or *Garbage Collector*, which is an overhead, takes care of this at run time.

The problems with manually freeing the memory are
- we could forget freeing
- We could free twice
- we could use after freeing 

So we need to exactly free once per allocation, which is a challenge.

## Ownership Rules:

```
- Each value in Rust has an owner.
- There can only be one owner at a time.
- When the owner goes out of scope, the value will be dropped.
```

Rust compiler will insert `drop()` call whenever the owner goes out of scope.

## Stack vs Heap:

When we run the program, `main` function is called. So this function call pushes a stack frame to stack. When we call a chain of functions or nested function inside main. All those calls pushes stack frames per function, so that when that execution completes, it exactly returns to the return address, which is the caller function.

So we use stack (Last In First Out), since the last called function is the first to return.

And the variables whose size is known at compile time - usually the u32, i32, bool etc. These are stored on stack, within the same stack frame and can be easily accessed - i.e., without allocation and deallocation of memory. 

But for variables having dynamic size, reference types those will be allocated memory on **heap**. When memory is allocated on heap, That pointer address is stored on stack and when this variable goes out of scope, memory is freed by calling `drop()`

## Ownership in Action:
- When the scope ends, drop gets called.
- When we pass a variable to a function, ownership is transferred. So we cannot use it later.
- When we assign a variable to another variable, ownership is moved. we cannot use if that variable allocation is on heap. Since on stack, this is not a problem rust does not restrict that.

``` Examples
```


