Problem
--------
For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more times).

Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.

```
Input: str1 = "ABABAB", str2 = "ABAB"
Output: "AB"
```

## Solution:

Reference: https://leetcode.com/problems/greatest-common-divisor-of-strings/editorial

```
class Solution:
    def gcdOfStrings(self, str1: str, str2: str) -> str:
        if str1+str2 != str2+str1:
            return ""
        
        if len(str1)<len(str2):
            short_string = str1
            short_length = len(str1) 
            long_string = str2
            long_length = len(str2) 
        else:
            short_string = str2
            short_length = len(str2)
            long_string = str1
            long_length = len(str1)

        def IsValid(string: str) -> bool:
            length = len(string)
            if short_length%length !=0 or long_length%length!=0:
                return False
            
            short_factor = short_length//length
            long_factor = long_length//length

            return short_factor*string == short_string and long_factor*string == long_string
        
        for i in range(short_length,-1,-1):
            if IsValid(short_string[:i]):
                return short_string[:i]
            #print(short_string[:i]+'did not pass')

```

## Complexity:

Consider short string to be 'm' characters long, long string to be 'n' characters long. In worst case, space needed is O(m+n) ~ O(n).

We loop n times and check validity. So Time complexity is O(n)

## Notes:

Euclids Algorithm, gcd using mod is not quite obvious. Still not very clear how it is working. 

- Getting the idea str1+str2 == str2+str1 is one key. 
- Getting started from shorter string is obvious. 
- Writing the IsValid properly is easy but needed. I should think modularly and write algorithm steps
- If we start from 0 --> length of shorter string, we will get smallest such x that divides both. Eg: ABABABAB, ABAB. we get answer AB. But that is not the answer we are looking for here. So we need to start from larger end and reduce. 


## Todo:
- Try to implement gcd using mod approach (Euclids algorithm)