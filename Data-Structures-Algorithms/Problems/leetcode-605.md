#leetcode75

Problem
-------
You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.

Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

## Solution:
   
### Algorithm:
1. for each plot
2. if plot is not empty continue.. check next plot
3. check previous plot not exists or empty.
4. check next plot not exists or empty 
5. place a plot

```class Solution:
    def canPlaceFlowers(self, flowerbed: List[int], n: int) -> bool:
        
        for i in range(len(flowerbed)):
            if n==0:
                # no flowers left to plant
                return True

            if flowerbed[i]:
                #there is already a flower, move on
                continue

            if i-1<0 or flowerbed[i-1]==0:
                # no or empty previous plot
                if i+1>=len(flowerbed) or flowerbed[i+1]==0:
                    #no or empty next plot
                    print(f"planting flower {n} at plot {i}")
                    flowerbed[i]=1
                    n-=1 

        return n==0    
```

But may be we could do better by using while loop and hopping over a spot when we find a planted plot.

## Complexity:
- Time: O(n)
- Space: O(1)