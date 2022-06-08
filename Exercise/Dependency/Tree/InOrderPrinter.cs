using System.Text;

namespace Function.Dependency.Tree;
public class Strings
{
    public static String Repeat(string? myString, int count)
    {
        if (myString == null) return null!;

        StringBuilder builder = new StringBuilder();
        while (count-- > 0)
        {
            builder.Append(myString);
        }

        return builder.ToString();
    }

    public static String Blank(int length)
    {
        if (length < 0) return null!;
        if (length == 0) return "";
        return "".PadRight(length,' ');
    }
}

public interface BinaryTreeInfo
{
    /**
     * who is the root node
     */
    public object Root();

    /**
     * how to get the left child of the node
     */
    public object Left(object node);

    /**
     * how to get the right child of the node
     */
    public object Right(object node);

    /**
     * how to print the node
     */
    public string GetString(object node);
}

public class InOrderPrinter
{
    private static readonly int length = 2;
    private static readonly string RightAppend = "┌" + Strings.Repeat("─", length);
    private static readonly string LeftAppend = "└" + Strings.Repeat("─", length);
    private static readonly string BlankAppend = Strings.Blank(length + 1);
    private static readonly string LineAppend = "│" + Strings.Blank(length);
    protected BinaryTreeInfo Tree;

    public InOrderPrinter(BinaryTreeInfo tree)
    {
        Tree = tree;
    }

    public String PrintString()
    {
        StringBuilder str = new StringBuilder(
            PrintString(Tree.Root(), "", "", ""));
        str.Remove(str.Length - 1,1);
        return str.ToString();
    }

    /// <summary>
    ///  生成node节点的字符串
    /// </summary>
    /// <param name="node"></param>
    /// <param name="nodePrefix">node那一行的前缀字符串</param>
    /// <param name="leftPrefix">node整棵左子树的前缀字符串</param>
    /// <param name="rightPrefix">node整棵右子树的前缀字符串</param>
    /// <returns></returns>
    private String PrintString(
        object node,
        String nodePrefix,
        String leftPrefix,
        String rightPrefix)
    {
        object left = Tree.Left(node);
        object right = Tree.Right(node);
        String str = Tree.GetString(node);

        int strLength = str.Length;
        if (strLength % 2 == 0)
        {
            strLength--;
        }

        strLength >>= 1;

        String nodeString = "";
        if (right != null!)
        {
            rightPrefix += Strings.Blank(strLength);
            nodeString += PrintString(right,
                rightPrefix + RightAppend,
                rightPrefix + LineAppend,
                rightPrefix + BlankAppend);
        }

        nodeString += nodePrefix + str + "\n";
        if (left != null!)
        {
            leftPrefix += Strings.Blank(strLength);
            nodeString += PrintString(left,
                leftPrefix + LeftAppend,
                leftPrefix + BlankAppend,
                leftPrefix + LineAppend);
        }

        return nodeString;
    }
}