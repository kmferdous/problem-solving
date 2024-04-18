public int MaxLevelSum(TreeNode root)
{
    if (root == null)
        return 0;

    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    long max = Int32.MinValue;
    int minLevel = 1;

    int len = 0, level = 0;
    long sum = 0;
    TreeNode node;

    // BFS
    while (queue.Any())
    {
        level++;
        len = queue.Count;
        sum = 0;

        while (len-- > 0)
        {
            node = queue.Dequeue();
            sum += node.val;

            if (node.left != null)
                queue.Enqueue(node.left);

            if (node.right != null)
                queue.Enqueue(node.right);
        }

        if (sum > max)
        {
            max = sum;
            minLevel = level;
        }
    }

    return minLevel;
}

/*
1161. Maximum Level Sum of a Binary Tree
Medium
Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.
Return the smallest level x such that the sum of all the values of nodes at level x is maximal.

Example 1:
Input: root = [1,7,0,7,-8,null,null]
Output: 2
Explanation: 
Level 1 sum = 1.
Level 2 sum = 7 + 0 = 7.
Level 3 sum = 7 + -8 = -1.
So we return the level with the maximum sum which is level 2.

Example 2:
Input: root = [989,null,10250,98693,-89388,null,null,null,-32127]
Output: 2
*/
