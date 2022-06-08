using Function.Dependency;

namespace Function.BinaryTree;

public class _94_二叉树的中序遍历
{
    public IList<int> OnOrderTraversal(TreeNode root)
    {
        IList<int> list = new List<int>();
        inOrderTraversal(root, list);
        return list;

    }

    private static void inOrderTraversal(TreeNode root, IList<int> list)
    {
        if (root == null!) return;
        list.Add(root.val);
        inOrderTraversal(root.left, list);
        inOrderTraversal(root.right, list);
    }
    public static IList<int> InOrderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null!) return result;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        bool goLeft = true;
        while (stack.Count > 0)
        {
            TreeNode  node = stack.Pop()!;
            if (node.left == null!) goLeft = false;
            if (goLeft)
            {
                stack.Push(node);
                stack.Push(node.left!);
                continue;
            }

            result.Add(node.val);
            if (node.right != null!)
            {
                goLeft = true;
                stack.Push(node.right);
            }
        }

        return result;
    }
}