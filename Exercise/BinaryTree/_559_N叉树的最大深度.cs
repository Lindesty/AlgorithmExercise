namespace Function.BinaryTree;

public class _559_N叉树的最大深度
{
    public int MaxDepth(Node root)
    {
        int maxDepth = 0;
        if (root is null)
        {
            return maxDepth;
        }

        int level = 1;
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            Node node = queue.Dequeue();
            level--;
            foreach (Node child in node.children)
            {
                queue.Enqueue(child);
            }

            if (level == 0)
            {
                maxDepth++;
                level = queue.Count;
            }
        }
        return maxDepth;
    }
}

public class Node
{
    public int val;
    public IList<Node> children;

    public Node()
    {
    }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}