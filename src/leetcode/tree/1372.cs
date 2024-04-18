public int LongestZigZag(TreeNode root)
{
    if (root == null)
        return 0;

    var leftLength = LongestZigZag(root, true, 0);
    var rightLength = LongestZigZag(root, false, 0);

    Console.WriteLine($"leftLength, rightLength = {Math.Max(leftLength, rightLength)}");

    return Math.Max(leftLength, rightLength) - 1;
}

private int LongestZigZag(TreeNode node, bool goLeft, int count)
{
    if (node == null)
        return count;

    if (goLeft)
    {
        return Math.Max(LongestZigZag(node.left, false, count + 1), LongestZigZag(node.right, true, 1));
    }
    else
    {
        return Math.Max(LongestZigZag(node.left, false, 1), LongestZigZag(node.right, true, count + 1));
    }
}


/*
1372. Longest ZigZag Path in a Binary Tree
Medium
You are given the root of a binary tree.
A ZigZag path for a binary tree is defined as follow:
Choose any node in the binary tree and a direction (right or left).
If the current direction is right, move to the right child of the current node; otherwise, move to the left child.
Change the direction from right to left or from left to right.
Repeat the second and third steps until you can't move in the tree.
Zigzag length is defined as the number of nodes visited - 1. (A single node has a length of 0).

Return the longest ZigZag path contained in that tree.

Example 1:
Input: root = [1,null,1,1,1,null,null,1,1,null,1,null,null,null,1]
Output: 3
Explanation: Longest ZigZag path in blue nodes (right -> left -> right).

Example 2:
Input: root = [1,1,1,null,1,null,null,1,1,null,1]
Output: 4
Explanation: Longest ZigZag path in blue nodes (left -> right -> left -> right).
*/
