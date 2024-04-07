public int NumIslands(char[][] grid)
{
    var count = 0;

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (IsIsland(grid, i, j, '1'))
            {
                count++;
                VisitAndUpdateAdjacent(grid, i, j);
            }
        }
    }

    return count;
}

private void VisitAndUpdateAdjacent(char[][] grid, int xIndex, int yIndex)
{
    if (!IsIsland(grid, xIndex, yIndex, '1'))
    {
        return;
    }

    grid[xIndex][yIndex] = '#';    // visited

    VisitAndUpdateAdjacent(grid, xIndex + 1, yIndex);
    VisitAndUpdateAdjacent(grid, xIndex - 1, yIndex);
    VisitAndUpdateAdjacent(grid, xIndex, yIndex + 1);
    VisitAndUpdateAdjacent(grid, xIndex, yIndex - 1);

    // restore not needed
}

private bool IsIsland(char[][] grid, int x, int y, char searchFor)
{
    return x >= 0 && x < grid.Length &&
           y >= 0 && y < grid[0].Length &&
           grid[x][y] == searchFor;
}

/*
200. Number of Islands
Medium
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume 
all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
*/
