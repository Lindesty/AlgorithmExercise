using Function.Dependency;

namespace Function.BinaryTree;

public class _145_二叉树的后序遍历
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        IList<int> list = new List<int>();
        postorderTraversal(root, list);
        return list;

    }

    private static void postorderTraversal(TreeNode root, IList<int> list)
    {
        if (root == null!) return;
        postorderTraversal(root.left, list);
        postorderTraversal(root.right, list);
        list.Add(root.val);
    }
}