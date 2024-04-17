public int GoodNodes(TreeNode root)
{
    if (root == null)
        return 0;

    return GoodNodes(root, Int32.MinValue);
}

public int GoodNodes(TreeNode root, int max)
{
    if (root == null)
        return 0;

    int count = 0;

    if (max <= root.val)
    {
        max = root.val;
        count++;
    }

    return count + GoodNodes(root.left, max) + GoodNodes(root.right, max);
}

/*
1448. Count Good Nodes in Binary Tree
Medium
Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.

Return the number of good nodes in the binary tree.
Example
Input: root = [3,1,4,3,null,1,5]
Output: 4
Explanation: Nodes in blue are good.
Root Node (3) is always a good node.
Node 4 -> (3,4) is the maximum value in the path starting from the root.
Node 5 -> (3,4,5) is the maximum value in the path
Node 3 -> (3,1,3) is the maximum value in the path.
*/
