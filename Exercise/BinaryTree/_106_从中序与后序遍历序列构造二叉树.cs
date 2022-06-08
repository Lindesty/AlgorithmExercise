using Function.Dependency;
using System.ComponentModel.Design.Serialization;

namespace Function.BinaryTree;

public class _106_从中序与后序遍历序列构造二叉树
{
    public static TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        if (inorder.Length == 0)
        {
            return null;
        }
        else if (inorder.Length == 1)
        {
            return new TreeNode(inorder[0]);
        }

        int rootValue = postorder[^1];
        int indexOfInOrder = inorder.ToList().IndexOf(rootValue);
        int[] leftInOrder = inorder[0..indexOfInOrder],
            leftPostOrder = postorder[0..indexOfInOrder],
            rightInOrder = inorder[(indexOfInOrder + 1)..],
            rightPostOrder = postorder[indexOfInOrder..^1];


        TreeNode root = new TreeNode(rootValue,
            left: BuildTree(leftInOrder, leftInOrder),
            right: BuildTree(rightInOrder, rightPostOrder));
        return root;
    }

    public static void Test()
    {
        int[] inorder = {2, 3, 1},
            postorder = {3, 2, 1};
        TreeNode rootNode = BuildTree(inorder, postorder);
        
    }
}
/*
 * 输入：inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
 * 输出：[3,9,20,null,null,15,7]                                                          1                                  
 *                                                3                              in [9] [3] [15,20,7] post [9] [15,7,20] [3]
 *                                               / \                           1                          1       
 *                 [9]  [9]                     9   20           inOrder[15] [20] [7]      postOrder[15] [7] [20]                       
 *                                                 /  \
 *                                                15   7                                
 *                                                                                    
 */