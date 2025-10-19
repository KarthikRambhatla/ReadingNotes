Problem
---------
You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1. If a string is longer than the other, append the additional letters onto the end of the merged string.

Return the merged string.

## Solution:
```
class Solution:
    def mergeAlternately(self, word1: str, word2: str) -> str:
        arranged_chars=[]
        ptr1, ptr2,len1,len2 = 0,0,len(word1),len(word2)
        while ptr1<len1 and ptr2<len2:
            arranged_chars.append(word1[ptr1])
            ptr1+=1
            arranged_chars.append(word2[ptr2])
            ptr2+=1
        if not ptr1<len1 and ptr2<len2:
            arranged_chars.append(word2[ptr2:])
        elif ptr1<len1 and not ptr2>len2:
            arranged_chars.append(word1[ptr1:])
        
        return "".join(arranged_chars)
        
```

### Hint:
- Use two pointers to traverse both strings.

### Complexity Analysis:
Time Complexity: O(n + m), where n and m are the lengths of word1 and word2 respectively.

## Notes:
- Think carefully taking two pointers and traversing them and handling condition when one string is longer than other.