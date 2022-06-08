using Function.Dependency;

namespace Function.BinaryTree;

public class _104_二叉树的最大深度
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
}