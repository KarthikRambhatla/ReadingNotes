Parallel - Two people working on two things - two threads

Concurrency - One person working on another task, when stuck on a task and coming back later - async await

Suppose we have one thread and we have two async methods. When we run both, we start a async method and in that when we await, we pause and continue on working something else, When that future is ready, which we know by polling, we resume that task. Meanwhile we might have reached await in the second task.

So we switch between these two tasks based on when they are ready to make progress. This is concurrency.

