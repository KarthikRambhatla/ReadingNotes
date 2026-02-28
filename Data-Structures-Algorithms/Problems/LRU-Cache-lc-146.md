#microsoft

Problem
--------

Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

Implement the LRUCache class:

LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
int get(int key) Return the value of the key if the key exists, otherwise return -1.
void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
The functions get and put must each run in O(1) average time complexity.

## Solution:

### Initial thoughts:
-----------------
Initially i thought it is easy to do, I thought of keeping a hashmap like a store to get the value for a key. And to keep track of the least recently used, we need some data structure. Suppose we have a simple array. everytime we have an operation we push that key onto it. Now the least recently used will be at the first position of array. But the problem is, 
Suppose we added [1,1] and [2,2] and the capacity of cache is 2. When we put/get, i want to push these keys to an array. So the array will consist of [1,2] and the hashmap consists of {1:1,2:2} but when we get 1, array: [1,2,1]. Now when we want to put 3 in cache since it exceeds capacity we want to remove it from cache. But look at our array, the least recently used is still 1. Using an array or Stack - we can have most recently acessed at the top, but that is not what we are looking for.

After scrolling through solutions, everyone uses a Doubly Linked List with a Hashmap. 

### Idea
----
The idea is that we want to keep most recently used at the head of linked list and next node will be next most recently used. Last most recently used will be the least recently used which lives at tail.

We will write a class Node, that will store Key, Value, Prev, Next pointers. Then we will have a Hashmap in LRUcache class that we call cache, which stores key -> Node
Even now, we will have two pointers mru and lru mru<->lru and we want to insert nodes in between. Everytime we do a put operation, we create a node, insert it at mru next.
Everytime we do a get, (the problem is still same when we thought of using array, so->) we remove the node and insert it at mru. The most important thing with this is that since we have the node in hashmap for the key. We get the node in O(1) and we can remove it in O(1) , just setting the somenode<->ournode<->othernode, we just remove it somenode<->othernode. Just playing with prev and next. And to keep it at the top, next to dummy mru. we just dummy_mru<->current_mru becomes dummy_mru<->ournode<->current_mru

```python

class LRUCache:

    def __init__(self, capacity: int):
        self.capacity = capacity
        self.cache={}
        self.mru = Node(0,0)
        self.lru = Node(0,0)
        self.mru.next,self.lru.prev = self.lru,self.mru

    def get(self, key: int) -> int:
        if not key in self.cache:
            return -1
        #update this key to recently used
        current_node = self.cache[key]
        self._remove_node(current_node)
        self._insert_node_at_mru(current_node)
        return current_node.val

    def put(self, key: int, value: int) -> None:
        if key in self.cache:
            node = self.cache[key]
            node.val = value
            self._remove_node(node)
        else:
            if len(self.cache)==self.capacity:
                current_lru = self.lru.prev
                del self.cache[current_lru.key]
                current_lru.prev.next = self.lru
                self.lru.prev = current_lru.prev
            node = Node(key,value)
            self.cache[key]=node
        self._insert_node_at_mru(node)    
    
    def _remove_node(self, node: Node):
        node.prev.next = node.next
        node.next.prev = node.prev
    
    def _insert_node_at_mru(self, node: Node):
        node.next = self.mru.next
        node.prev = self.mru
        self.mru.next.prev = node
        self.mru.next = node


        
class Node:

    def __init__(self, key, val):
        self.key = key
        self.val = val
        self.prev = self.next = None
    


# Your LRUCache object will be instantiated and called as such:
# obj = LRUCache(capacity)
# param_1 = obj.get(key)
# obj.put(key,value)
```
