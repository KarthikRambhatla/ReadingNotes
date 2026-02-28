#geeksforgeeks

Problem
-------
Given two arrays start[] and end[] such that start[i] is the starting time of ith meeting and end[i] is the ending time of ith meeting. Return the minimum number of rooms required to attend all meetings.

Note: A person can also attend a meeting if it's starting time is same as the previous meeting's ending time.

Examples:

    Input: start[] = [1, 10, 7], end[] = [4, 15, 10]
    Output: 1
Explanation: Since all the meetings are held at different times, it is possible to attend all the meetings in a single room.

    Input: start[] = [2, 9, 6], end[] = [4, 12, 10]
    Output: 2

Explanation: 1st and 2nd meetings at one room but for 3rd meeting one another room required.

- Constraints:

        1 ≤ start.size() = end.size() ≤ 105
        0 ≤ start[i] < end[i] ≤ 106

## Solution:

### Initial Idea

When we have start time before an end time of a meeting, we need another room. But once we have second room, it becomes a bit difficult to wrap head around how to organize this.

What exactly we are asking ourselves is, What is the max number of meetings that are happening simultaneously?

Even this feels hard. Everytime a meeting starts a room gets occupied and when ends it gets freed. For every start time a room occupies and for every end time a room frees. So if we sort both start times and end times and occupy +1 and free -1. Then track the max of it, then we know what is the max numer of meetings that happen in parallel.

When we occupy a room when the meeting starts before end of earlier meeting, we increase rooms+=1. If room starts after end of earlier meeting, we should not increase.

so i need to have start_pointer=0, end_pointer=0 while start_pointer is still inside start array,  if start[start_pointer]<end[end_pointer] then start_pointer+=1 rooms+=1 max_rooms = max(rooms,max_rooms). But if start time crosses end time rooms-=1 end_pointer+=1

```Python

class Solution:
    def minMeetingRooms(self, start, end):
        # code here
        start.sort()
        end.sort()
        start_pointer,end_pointer=0,0
        rooms,max_rooms=0,0
        while start_pointer<len(start):
            if start[start_pointer] < end[end_pointer]:
                start_pointer += 1
                rooms += 1
                max_rooms = max(max_rooms,rooms)
            else:
                end_pointer+=1
                rooms-=1
        return max_rooms
```