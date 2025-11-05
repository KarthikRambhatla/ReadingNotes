- We want to have multiple owners, then we wrap it with RC, `RC<T>` this is a reference counter. So we can clone this and pass to multiple owners. And each time we clone, the count internally increases.and When the owners go out of scope, count decreases. When finally no owners are there, it gets dropped.

But this is for single threaded scenario. We cannot pass this safely between threads. We should use `Arc<T>` for that - Atomic Reference counting
