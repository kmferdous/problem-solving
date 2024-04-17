public bool LeafSimilar(TreeNode root1, TreeNode root2)
{
    if (root1 == null && root2 == null)
        return true;

    var leftValues = new List<int>();
    var rightValues = new List<int>();

    if (root1 != null)
        GetLeaves(root1, leftValues);
    if (root2 != null)
        GetLeaves(root2, rightValues);

    if (leftValues.Count != rightValues.Count)
        return false;

    for (int i = 0; i < leftValues.Count; i++)
    {
        if (leftValues[i] != rightValues[i])
            return false;
    }

    return true;
}

private void GetLeaves(TreeNode node, List<int> values)
{
    if (node == null)
        return;

    if (node.left == null && node.right == null)
    {
        values.Add(node.val);
        return;
    }

    GetLeaves(node.left, values);
    GetLeaves(node.right, values);
}

/*
872. Leaf-Similar Trees
Easy
Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.
For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
Two binary trees are considered leaf-similar if their leaf value sequence is the same.
Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.

Example
Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
Output: true
*/
