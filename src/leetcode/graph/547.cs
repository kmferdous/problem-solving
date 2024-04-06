public int FindCircleNum(int[][] isConnected)
{
    int count = 0;
    var visitedArr = new int[isConnected.Length];

    for (int i = 0; i < visitedArr.Length; i++)
    {
        if (visitedArr[i] != 1)
        {
            count++;
            GetCircleNum(isConnected, visitedArr, i);
        }
    }

    return count;
}

private void GetCircleNum(int[][] isConnected, int[] visitedArr, int num)
{
    if (visitedArr[num] == 1)
    {
        return;
    }

    visitedArr[num] = 1;

    for (int i = 0; i < visitedArr.Length; i++)
    {
        if (isConnected[num][i] == 1)
        {
            GetCircleNum(isConnected, visitedArr, i);
        }
    }
}

/*
547. Number of Provinces
Medium
There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b,
and city b is connected directly with city c, then city a is connected indirectly with city c.
A province is a group of directly or indirectly connected cities and no other cities outside of the group.
You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected,
and isConnected[i][j] = 0 otherwise.

Return the total number of provinces.

Example 1:
Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
Output: 2
*/
