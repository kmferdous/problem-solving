public int MaxDepth(TreeNode root)
{
    if (root == null)
        return 0;

    return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
}

/*
104. Maximum Depth of Binary Tree
Easy
Given the root of a binary tree, return its maximum depth.

A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

Example
Input: root = [3,9,20,null,null,15,7]
Output: 3
*/
