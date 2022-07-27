namespace Function.Dependency.Tree;

public class AvlTree<T> : BST<T>
{
    public AvlTree(IComparer<T>? comparator) : base(comparator)
    {
    }

    public AvlTree() : base(null)
    {
    }


    protected override void AfterAdd(TreeNode<T> node)
    {
        while ((node = node.Parent) != null)
        {
            if (IsBalanced(node))
            {
                //更新高度
                UpdateHeight(node);
            }
            else
            {
                //恢复平衡


                Rebalance(node);
                //整棵树恢复平衡
                break;
            }
        }
    }

    /// <summary>
    /// 恢复二叉树平衡
    /// </summary>
    /// <param name="node"></param>
    private void Rebalance(TreeNode<T> node)
    {
    }

    private void UpdateHeight(TreeNode<T> node)
    {
        (node as AvlNode<T>)!.UpdateHeight();
    }

    protected override TreeNode<T> CreateNode(T value, TreeNode<T> parent) => new AvlNode<T>(value, parent);


    public bool IsBalanced(TreeNode<T>? node)
    {
        if (node == null)
        {
            return true;
        }

        int leftHeight = node.Left == null! ? 0 : node.Left.Height;
        int rightHeight = node.Right == null! ? 0 : node.Right.Height;
        int cmp = leftHeight - rightHeight;
        if (cmp > 1 || cmp < -1)
        {
            return false;
        }

        return true;
    }
}

public class AvlNode<T> : TreeNode<T>
{
    public sealed override int Height { get; set; }

    public AvlNode(T value, TreeNode<T> parent) : base(value, parent)
    {
        Height = 1;
    }

    public void UpdateHeight()
    {
        int leftHeight = this.Left == null! ? 0 : this.Left.Height;
        int rightHeight = this.Right == null! ? 0 : this.Right.Height;
        this.Height = 1 + Math.Max(leftHeight, rightHeight);
    }
}