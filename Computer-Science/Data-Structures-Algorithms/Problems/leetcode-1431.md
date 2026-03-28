Problem
----------
There are n kids with candies. You are given an integer array candies, where each candies[i] represents the number of candies the ith kid has, and an integer extraCandies, denoting the number of extra candies that you have.

Return a boolean array result of length n, where result[i] is true if, after giving the ith kid all the extraCandies, they will have the greatest number of candies among all the kids, or false otherwise.

Note that multiple kids can have the greatest number of candies

## Solution:

```
class Solution:
    def kidsWithCandies(self, candies: List[int], extraCandies: int) -> List[bool]:
        max_candies = max(candies)
        res=[]
        for i in candies:
            if i+extraCandies >= max_candies:
                res.append(True)
            else:
                res.append(False)
        return res
```

## Complexity:

- Time: O(n)
- Space: O(1)
