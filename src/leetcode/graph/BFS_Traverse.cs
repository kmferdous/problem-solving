private record Cell(int Row, int Col);

public int CalleeMethod(int[][] grid)
{
    Queue<Cell> queue = new Queue<Cell>();
    // enqueue according to condition. Loop if needed.

    return VisitAdjacent(grid, queue);
}

private int VisitAdjacent(int[][] grid, Queue<Cell> queue)
{
    int level = 0;
    while (queue.Count > 0)
    {
        level++;
        // traverse all node of that level
        var size = queue.Count;
        for (int i = 0; i < size; i++)
        {
            var cell = queue.Dequeue();
            EnqueueIfValid(grid, new Cell(cell.Row + 1, cell.Col), queue);
            EnqueueIfValid(grid, new Cell(cell.Row - 1, cell.Col), queue);
            EnqueueIfValid(grid, new Cell(cell.Row, cell.Col + 1), queue);
            EnqueueIfValid(grid, new Cell(cell.Row, cell.Col - 1), queue);
        }
    }

    return level;
}

private void EnqueueIfValid(int[][] grid, Cell cell, Queue<Cell> queue)
{
    if (cell.Row >= 0 && cell.Row < grid.Length &&
        cell.Col >= 0 && cell.Col < grid[0].Length
        // grid[cell.Row][cell.Col] ==  criteria
        )
    {
        queue.Enqueue(cell);
        // grid[cell.Row][cell.Col] = symbol; // mark as visited
    }
}
