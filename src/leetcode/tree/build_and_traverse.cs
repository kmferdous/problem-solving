public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public TreeNode BuildTree(int?[] nums)
{
    if (nums == null || nums.Length == 0)
    {
        return null;
    }

    var queue = new Queue<TreeNode>();

    var root = new TreeNode(nums[0].Value);
    queue.Enqueue(root);
    
    TreeNode cur;
    int i = 1;

    while (i < nums.Length)
    {
        cur = queue.Dequeue();

        if (i < nums.Length && nums[i] != null)
        {
            cur.left = new TreeNode(nums[i].Value);
            queue.Enqueue(cur.left);
        }

        i++;

        if (i < nums.Length && nums[i] != null)
        {
            cur.right = new TreeNode(nums[i].Value);
            queue.Enqueue(cur.right);
        }

        i++;
    }

    return root;
}

public void PreOrderPrint(TreeNode node)
{
    if (node == null)
        return;

    Console.Write(node.val + " ");
    PreOrderPrint(node.left);
    PreOrderPrint(node.right);
}

public void InOrderPrint(TreeNode node)
{
    if (node == null)
        return;

    PreOrderPrint(node.left);
    Console.Write(node.val + " ");
    PreOrderPrint(node.right);
}

public void PostOrderPrint(TreeNode node)
{
    if (node == null)
        return;

    PreOrderPrint(node.left);
    PreOrderPrint(node.right);
    Console.Write(node.val + " ");
}
