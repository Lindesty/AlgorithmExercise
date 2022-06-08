using Function.Dependency;

namespace Function.BinaryTree;

public class _144__二叉树的前序遍历
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> list = new List<int>();
        preorderTraversal(root,list);
        return list;

    }

    private static void preorderTraversal(TreeNode root, IList<int> list)
    {
        if (root == null!) return;
        list.Add(root.val);
        preorderTraversal(root.left, list);
        preorderTraversal(root.right, list);
    }

    public IList<int> PreorderTraversal_0(TreeNode root)
    {
        IList<int> result = new List<int>();
        if(root == null!) return result;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();
            result.Add(node.val);
            if (node.right != null!) stack.Push(node.right);
            if (node.left != null!) stack.Push(node.left);
        }
        return result;
    }

}