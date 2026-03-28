#microsoft

Problem
-------
Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

### Initial Idea

Trapped water depends on boundaries. After some not so well formed ideas and going though solution. The idea is we want to know left wall and right wall height. Minimum of those heights will determine how much water we can keep at a height h. The water will overflow minimum and just stay at minimum wall height.

    water at height h = min(max height to left, max height to right) - current height

Now, for each height at i, we can loop again and see max height from 0->i
and loop from i+1-> n to see right max

Let's say we have heights [2,3,2,2,2] no water can be stored. at `2`, max left is `2`, at `3` max left is `3`, at `2` again max left is `3` but max right is `2`. so at every height it is just `0` water

### Code

```python
class Solution:
    def trap(self, height: List[int]) -> int:
        n=len(height)
        #water at height h = min(max left wall height, max right wall height)-h
        
        water = 0
        for i in range(n):
            maxLeft=maxRight=height[i]
            for j in range(i):
                maxLeft = max(maxLeft,height[j])
            for j in range(n-1,i,-1):
                maxRight = max(maxRight,height[j])
            water+= min(maxLeft,maxRight)-height[i]
        return water
```

### Time Complexity and Space Complexity

For each height, we are scanning from 0->i and i<-n-1 
i.e., to get each height O(n) and for each height again getting max left, maxRight is O(n)

Overall, it becomes O(n^2)

### Next Idea:

We can precompute max left and max right for each height and store it in an array. So we can get max left and max right in O(1) time. Now since we have arrays, Space complexity becomes O(n).

```python

```