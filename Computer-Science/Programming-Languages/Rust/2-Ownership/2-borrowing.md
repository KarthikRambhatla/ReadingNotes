## Borrowing

To pass a variable without transferring ownership, we use borrowing. We pass the reference `&` and the function does not own it, But uses it but the ownership stays with the passer.

But this is an immutable reference, The function cannot mutate the variable.

If the function intends to change the variable, we need to pass a mutable reference.

## Rules:

- We can have any number of immutable references borrowed.
- we can only have one mutable reference borrowed.
- We cannot have both mutable and immutable references at the same time. 