private record Cell(int Row, int Col);

public int NearestExit(char[][] maze, int[] entrance)
{
    var entranceCell = new Cell(entrance[0], entrance[1]);
    var queue = new Queue<Cell>();

    queue.Enqueue(entranceCell);
    
    return VisitAdjacentForNearestExit(maze, entranceCell, queue);
}

private int VisitAdjacentForNearestExit(char[][] maze, Cell entrance, Queue<Cell> queue)
{
    var pathLength = 0;
    
    while (queue.Count > 0)
    {
        pathLength++;
        var size = queue.Count;

        for (int i = 0; i < size; i++)
        {
            var cell = queue.Dequeue();

            Console.WriteLine($"[{cell.Row}, {cell.Col}]");

            if (!(cell.Row == entrance.Row && cell.Col == entrance.Col) &&
                (cell.Row == 0 || cell.Row == maze.Length - 1 || 
                 cell.Col == 0 || cell.Col == maze[0].Length - 1))
            {
                return pathLength - 1;
            }

            AddIntoQueueIfValid(maze, entrance, new Cell(cell.Row + 1, cell.Col), queue);
            AddIntoQueueIfValid(maze, entrance, new Cell(cell.Row - 1, cell.Col), queue);
            AddIntoQueueIfValid(maze, entrance, new Cell(cell.Row, cell.Col + 1), queue);
            AddIntoQueueIfValid(maze, entrance, new Cell(cell.Row, cell.Col - 1), queue);
        }
    }

    return -1;
}

private void AddIntoQueueIfValid(char[][] maze, Cell entrance, Cell cell, Queue<Cell> queue)
{
    if (!(cell.Row == entrance.Row && cell.Col == entrance.Col) &&
        cell.Row >= 0 && cell.Row < maze.Length && 
        cell.Col >= 0 && cell.Col < maze[0].Length &&
        maze[cell.Row][cell.Col] == '.')
    {
        queue.Enqueue(cell);
        maze[cell.Row][cell.Col] = '+'; // mark as visited
    }
}

/*
1926. Nearest Exit from Entrance in Maze
Medium
You are given an m x n matrix maze (0-indexed) with empty cells (represented as '.') and walls (represented as '+'). 
You are also given the entrance of the maze, where entrance = [entrancerow, entrancecol] denotes the row and column of the cell you are initially standing at.

In one step, you can move one cell up, down, left, or right. You cannot step into a cell with a wall, and you
cannot step outside the maze. Your goal is to find the nearest exit from the entrance. An exit is defined as an 
empty cell that is at the border of the maze. The entrance does not count as an exit.

Return the number of steps in the shortest path from the entrance to the nearest exit, or -1 if no such path exists.

Example 1:
Input: maze = [["+","+",".","+"],[".",".",".","+"],["+","+","+","."]], entrance = [1,2]
Output: 1
Explanation: There are 3 exits in this maze at [1,0], [0,2], and [2,3].
Initially, you are at the entrance cell [1,2].
- You can reach [1,0] by moving 2 steps left.
- You can reach [0,2] by moving 1 step up.
It is impossible to reach [2,3] from the entrance.
Thus, the nearest exit is [0,2], which is 1 step away.
*/
