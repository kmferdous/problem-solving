public TreeNode DeleteNode(TreeNode root, int key) 
{
    if (root == null)
    {
        return root;
    }

    if (key < root.val)
    {
        root.left = DeleteNode(root.left, key);
    }
    else if (key > root.val)
    {
        root.right = DeleteNode(root.right, key);
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
            root.right = DeleteNode(root.right, root.val);
        }
    }

    return root;
}

/*
450. Delete Node in a BST
Medium
Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.
Basically, the deletion can be divided into two stages:

Search for a node to remove.
If the node is found, delete the node.
*/
