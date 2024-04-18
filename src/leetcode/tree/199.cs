public IList<int> RightSideView(TreeNode root)
{
    var list = new List<int>();

    if (root == null)
        return list; 
    
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    int len = 0;
    TreeNode node;

    // BFS
    while (queue.Any())
    {
        len = queue.Count;

        while (len-- > 0)
        {
            node = queue.Dequeue();

            if (node.left != null)
                queue.Enqueue(node.left);
            if (node.right != null)
                queue.Enqueue(node.right);

            if (len == 0)
                list.Add(node.val);
        }
    }

    foreach (var item in list)
    {
        Console.WriteLine(item);
    }

    return list;
}

/*
199. Binary Tree Right Side View
Medium
Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

Example 1:
Input: root = [1,2,3,null,5,null,4]
Output: [1,3,4]

Example 2:
Input: root = [1,null,3]
Output: [1,3]
*/
