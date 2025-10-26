`Send` implies it is Safe to Move ownership across threads. Example: Vec, String, Arc, Mutex implements `Send` whereas Rc, Raw pointer does not implement.

`Sync`	implies we can safely Share immutable references across threads. Example: Arc, Mutex, RwLock implements `Sync` whereas Cell, RefCell, Rc does not implement that.

`any type T implements Sync if &T (an immutable reference to T) implements Send, meaning the reference can be sent safely to another thread`

