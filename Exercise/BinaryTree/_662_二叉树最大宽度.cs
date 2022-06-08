using Function.Dependency;

namespace Function.BinaryTree;

public class _662_二叉树最大宽度
{
    public static int WidthOfBinaryTree(TreeNode root)
    {
        int maxLevel = 0;
        if (root is null)
        {
            return maxLevel;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        int level = 1;
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            TreeNode node = queue.Dequeue();
            if (node is null)
            {
                continue;
            }
            level--;
            if (node.left is not null && node.right is not null)
            {
                queue.Enqueue(node.right);
                queue.Enqueue(node.left);
            }
            if (level == 0)
            {
                level = queue.Count;
                if (level > maxLevel)
                {
                    maxLevel = level;
                }
            }
        }
        return maxLevel;
    }
}