private record Cell(int Row, int Col);

public int OrangesRotting(int[][] grid)
{
    var queue = new Queue<Cell>();

    var freshOrangeCount = 0;
    for (int row = 0; row < grid.Count(); row++)
    {
        for (int col = 0; col < grid[0].Count(); col++)
        {
            if (grid[row][col] == 2) // rotten
            {
                queue.Enqueue(new Cell(row, col));
            }
            else if (grid[row][col] == 1)
            {
                freshOrangeCount++;
            }
        }
    }

    if (freshOrangeCount == 0)
        return 0;

    return VisitAdjacentOranges(grid, queue);
}

private int VisitAdjacentOranges(int[][] grid, Queue<Cell> queue)
{
    int minutes = 0;
    while (queue.Count > 0)
    {
        minutes++;
        var size = queue.Count;
        for (int i = 0; i < size; i++)
        {
            var cell = queue.Dequeue();

            EnqueueIfValidOranges(grid, new Cell(cell.Row + 1, cell.Col), queue);
            EnqueueIfValidOranges(grid, new Cell(cell.Row - 1, cell.Col), queue);
            EnqueueIfValidOranges(grid, new Cell(cell.Row, cell.Col + 1), queue);
            EnqueueIfValidOranges(grid, new Cell(cell.Row, cell.Col - 1), queue);
        }
    }

    for (int row = 0; row < grid.Count(); row++)
    {
        for (int col = 0; col < grid[0].Count(); col++)
        {
            if (grid[row][col] == 1) // any fresh
            {
                return -1;
            }
        }
    }

    return minutes - 1;
}

private void EnqueueIfValidOranges(int[][] grid, Cell cell, Queue<Cell> queue)
{
    if (cell.Row >= 0 && cell.Row < grid.Length &&
        cell.Col >= 0 && cell.Col < grid[0].Length &&
        grid[cell.Row][cell.Col] ==1
       )
    {
        queue.Enqueue(cell);
        grid[cell.Row][cell.Col] = 2; // mark as visited
    }
}

/*
994. Rotting Oranges
Medium
You are given an m x n grid where each cell can have one of three values:
0 representing an empty cell,
1 representing a fresh orange, or
2 representing a rotten orange.
Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.

Example 1:
Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
Output: 4

Example 2:
Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
Output: -1
Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.

Example 3:
Input: grid = [[0,2]]
Output: 0
Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.
*/
