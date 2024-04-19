public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
{
    LowestCommonAncestor(root, new List<TreeNode>{p, q}, 0, out TreeNode? ancestor);

    return ancestor;
}

private int LowestCommonAncestor(TreeNode? root, List<TreeNode> nodes, int count, out TreeNode? ancestor)
{
    ancestor = null;

    if (root == null)
        return count;

    var ancestorAble = count == 0;

    Console.WriteLine(root.val);

    if (nodes.Contains(root))
    {
        if (++count == nodes.Count)
        {
            return count;
        }
    }

    count = LowestCommonAncestor(root.left, nodes, count, out ancestor);

    if (count == nodes.Count && ancestorAble && ancestor == null)
    {
        ancestor = root;
    }
    else if (count == nodes.Count)
    {
        return count;
    }

    count = LowestCommonAncestor(root.right, nodes, count, out ancestor);

    if (count == nodes.Count && ancestorAble && ancestor == null)
    {
        ancestor = root;
    }

    return count;
}

/*
236. Lowest Common Ancestor of a Binary Tree
Medium
Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q 
as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

Example 1:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
Output: 3
Explanation: The LCA of nodes 5 and 1 is 3.

Example 2:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
Output: 5
Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
*/
