using Function.Dependency;

namespace Function.BinaryTree;

public class _102_二叉树的层序遍历
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> list = new List<IList<int>>();
        if (root == null!) return list;
        List<int> tmp = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int level = 1;
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            level--;
            tmp.Add(node.val);

            if (node.left != null!)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null!)
            {
                queue.Enqueue(node.right);
            }

            if (level == 0)
            {
                level = queue.Count;
                list.Add(new List<int>(tmp));
                tmp.Clear();
            }


        }


        return list;
    }
}