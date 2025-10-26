- When we have a recursive data structure, rust cannot determine its size. So we need to Box it, It means that we store the pointer pointing to that address in memory instead of storing actual object in this object. 

suppose we have a `List` that contains a `i32` and `List` or `nil`. This is like a `Linked List`. Rust cannot determine the size, since worst case, it is infinite.

When we store `Box<List>` instead of `List` inside the `List` we just store the pointer and `deref` trait is implemented on this, so we can read it.

When this Box variable goes out of scope the `drop` gets called.