public bool Exist(char[][] board, string word)
{
    for (int i = 0; i < board.Length; i++)
    {
        for (int j = 0; j < board[i].Length; j++)
        {
            if (CheckAndVisitAdjacent(board, word, i, j, 0))
            {
                return true;
            }
        }
    }

    return false;
}

private bool CheckAndVisitAdjacent(char[][] board, string word, int xIndex, int yIndex, int wordIndex)
{
    if (wordIndex == word.Length)
    {
        return true;
    }

    if (!IsValidNode(board, xIndex, yIndex, word[wordIndex]))
    {
        return false;
    }

    var value = board[xIndex][yIndex];  // store for restore

    board[xIndex][yIndex] = '#';    // visited
    wordIndex++;

    var found = CheckAndVisitAdjacent(board, word, xIndex + 1, yIndex, wordIndex) ||
                CheckAndVisitAdjacent(board, word, xIndex - 1, yIndex, wordIndex) ||
                CheckAndVisitAdjacent(board, word, xIndex, yIndex + 1, wordIndex) ||
                CheckAndVisitAdjacent(board, word, xIndex, yIndex - 1, wordIndex);

    board[xIndex][yIndex] = value;  // restore 

    return found;
}

private bool IsValidNode(char[][] board, int x, int y, char searchFor)
{
    return x >= 0 && x < board.Length &&
           y >= 0 && y < board[0].Length &&
           board[x][y] == searchFor;
}

/*
79. Word Search
Medium
Given an m x n grid of characters board and a string word, return true if word exists in the grid.
The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are 
horizontally or vertically neighboring. The same letter cell may not be used more than once.

Example 1:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true
*/
