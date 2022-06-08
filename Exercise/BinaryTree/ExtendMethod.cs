using System.Text;
using Function.Dependency;
using Function.Dependency.Tree;

namespace Function.BinaryTree;


public static class ExtendMethod
{
    public static TreeNode CreateTreeSimple(int[] list)
    {
        if (list.Length == 0)
        {
            return null;
        }

        int i = 0;
        TreeNode root = new TreeNode(list[i++], null!, null!);
        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);
        for (int j = i; j < list.Length; j += 2)
        {
            TreeNode treeNode = queue.Dequeue();


            treeNode.left = new TreeNode(list[j], null!, null!);
            queue.Enqueue(treeNode.left);
            if (j + 1 < list.Length)
            {
                treeNode.right = new TreeNode(list[j + 1], null!, null!);
                queue.Enqueue(treeNode.right);
            }
        }

        return root;
    }

    public static void ShowList<T>(this List<T> list)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('[');
        foreach (T item in list)
        {
            sb.Append(item).Append(',');
        }

        sb[^1] = ']';
        Console.WriteLine(sb.ToString());
    }

    public static void ShowList<T>(this IList<IList<T>> list, Func<IList<T>, string> toString)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('[');
        foreach (var item in list)
        {
            sb.Append(toString(item)).Append(',');
        }

        sb[^1] = ']';
        Console.WriteLine(sb.ToString());
    }

    public static string ListToString<T>(this IList<T> list)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('[');
        foreach (T item in list)
        {
            sb.Append(item).Append(',');
        }

        sb[^1] = ']';
        return sb.ToString();
    }
}