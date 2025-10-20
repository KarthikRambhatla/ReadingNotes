#neetcode150

Problem
----------
Given an integer array nums, return true if any value appears more than once in the array, otherwise return false.

## Solution

```
class Solution:
    def hasDuplicate(self, nums: List[int]) -> bool:
        set_nums = set()
        for num in nums:
            if num in set_nums:
                return True
            set_nums.add(num)
        return False
```
