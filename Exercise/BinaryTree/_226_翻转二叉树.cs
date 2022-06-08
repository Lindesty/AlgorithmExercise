using Function.Dependency.Tree;

namespace Function.BinaryTree;

public class _226_翻转二叉树
{
    public static TreeNode<T> InvertTree<T>(TreeNode<T> root)
    {
        if (root == null!)
        {
            return null!;
        }

        TreeNode<T> leftNode = InvertTree<T>(root.Left);
        root.Left = InvertTree<T>(root.Right);
        root.Right = leftNode;
        return root;
    }
}