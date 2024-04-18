public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

private TreeNode InsertIntoBST(TreeNode? root, int val)
{
    if (root == null)
    {
        return new TreeNode(val);
    }
    
    if (val < root.val)
    {
        root.left = InsertIntoBST(root.left, val);
    }
    else if (val > root.val)
    {
        root.right = InsertIntoBST(root.right, val);
    }

    return root;
}

private TreeNode? FindFromBST(TreeNode? root, int val)
{
    while (root != null)
    {
        if (val < root.val)
        {
            root = root.left;
        }
        else if (val > root.val)
        {
            root = root.right;
        }
        else
        {
            return root;
        }
    }

    return null;
}

private TreeNode? DeleteFromBST(TreeNode? root, int val)
{
    if (root == null)
    {
        return root;
    }
    
    if (val < root.val)
    {
        root.left = DeleteFromBST(root.left, val);
    }
    else if (val > root.val)
    {
        root.right = DeleteFromBST(root.right, val);
    }
    else
    {
        if (root.left == null)
        {
            return root.right;
        }
        else if (root.right == null)
        {
            return root.left;
        }
        else
        {
            var leftMostNodeOfRightSubTree = root.right;

            // get the left most node of right subtree
            while (leftMostNodeOfRightSubTree.left != null)
            {
                leftMostNodeOfRightSubTree = leftMostNodeOfRightSubTree.left;
            }

            root.val = leftMostNodeOfRightSubTree.val;

            // now delete that left most node
            root.right = DeleteFromBST(root.right, root.val);
        }
    }

    return root;
}

public TreeNode BuildBST(int?[] nums)
{
    if (nums == null || nums.Length == 0)
    {
        return null;
    }

    var root = new TreeNode(nums[0].Value);
    int i = 1;

    while (i < nums.Length)
    {
        InsertIntoBST(root, nums[i].Value);

        i++;
    }

    return root;
}
