#leetcode-88

Problem
---------
You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

Merge nums1 and nums2 into a single array sorted in non-decreasing order.

The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

## Solution

### Initial thoughts
--------------------
Initially i thought of using a single linked list, so that i can push them in between. But that will use extra space and creating one from the array and again going through it to return. But we need to do this in place of nums1.

### Idea
--------

After looking through solutions, comparing arrays from the end and placing them in nums1 is the correct approach. But i was unnecessarily swapping the nums1 value again in the else block. like nums1[ptr1]=nums2[ptr2]. No. We just reduce the index and whichever is bigger from both arrays sits at index. At the end, if array 2 is not completed, we assign array2 values to index in nums1.

```Python
class Solution:
    def merge(self, nums1: List[int], m: int, nums2: List[int], n: int) -> None:
        """
        Do not return anything, modify nums1 in-place instead.
        """
        ptr2 = n-1
        ptr1 = m-1
        index=m+n-1
        while ptr2>-1 and ptr1>-1:
            if nums2[ptr2]>=nums1[ptr1]:
                nums1[index]=nums2[ptr2]
                ptr2-=1
            else:
                nums1[index]=nums1[ptr1]
                ptr1-=1
            index-=1
        
        while ptr2>-1 and index>-1:
            nums1[index] = nums2[ptr2]
            index-=1
            ptr2-=1
```
