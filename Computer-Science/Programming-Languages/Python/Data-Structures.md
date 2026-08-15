## Core Data Structures & Mutability

### List:  
 [1,2,3]
- Ordered, Mutable sequences
- Ideal for dynamic arrays, stacks, sliding window patterns
- Insertion/Deletion at the end is O(1)
- Inserting at front is O(n)

### Tuple:
(1,2,3)
- Ordered, Immutable sequences
- Hashable, so can be used as keys in dictionary
- commonly used to pack multiple return values from functions

### Dictionaries
{'a':1}
- Unordered (ordered by insertion since 3.7)
- average O(1) lookup, insertion and deltion
- keys must be immutable types (strings, integers, tuples)

### Sets
{1,2,3}
- Unordered collection of unique, immutable elements
- O(1) time complexity for membership tests (in)
- Fast deduplication, set math ops like unions, intersections

