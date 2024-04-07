class IslandNode
{
    public int xIndex;
    public int yIndex;

    public IslandNode(int x, int y)
    {
        xIndex = x;
        yIndex = y;
    }
}

public int NumIslands(char[][] grid)
{
    var queue = new Queue<IslandNode>();
    int result = 0;

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (EnqueueIfValidLand(grid, queue, i, j))
            {
                result++;
                VisitAdjacent(grid, queue);
            }
        }
    }

    return result;
}

private void VisitAdjacent(char[][] grid, Queue<IslandNode> queue)
{
    while (queue.Count > 0)
    {
        var node = queue.Dequeue();

        EnqueueIfValidLand(grid, queue, node.xIndex + 1, node.yIndex);
        EnqueueIfValidLand(grid, queue, node.xIndex - 1, node.yIndex);
        EnqueueIfValidLand(grid, queue, node.xIndex, node.yIndex + 1);
        EnqueueIfValidLand(grid, queue, node.xIndex, node.yIndex - 1);
    }
}

private bool EnqueueIfValidLand(char[][] grid, Queue<IslandNode> queue, int x, int y)
{
    if (x >= 0 &&
         x < grid.Length &&
         y >= 0 &&
         y < grid[0].Length &&
         grid[x][y] == '1')
    {
        grid[x][y] = '0';
        queue.Enqueue(new IslandNode(x, y));

        return true;
    }

    return false;
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
