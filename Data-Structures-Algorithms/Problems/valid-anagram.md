#neetcode150

Problem
-------
Given two strings s and t, return true if the two strings are anagrams of each other, otherwise return false.

An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.

## Solution

Approach 1:

We could just sort both strings and compare. 
```
class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        if len(s)!=len(t):
            return False
        return sorted(s)==sorted(t)
```

Approach 2:
```
```