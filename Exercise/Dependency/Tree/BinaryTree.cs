using System.Collections;
using System.Text;

namespace Function.Dependency.Tree;

public class BinaryTree<T>:IEnumerable<T>
{
    protected int _size;
    public virtual int Height => (_root!.Height);
    protected TreeNode<T>? _root;
    public int Size => _size;
    public TreeNode<T>? Root => _root;

    public BinaryTree(IEnumerable<T>? list)
    {
        if (list == null)
        {
            return;
        }
        _root = CreateTree(list.ToArray());
    }

    public BinaryTree() : this(null)
    {
        _root = null;
    }

    /// <summary>
    /// 找到node的前驱结点，找不到返回null
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public TreeNode<T>? PredecessorNode(TreeNode<T>? node)
    {
        if (node is null) return null;
        TreeNode<T>? predecessorNode = null;
        //前驱结点在左子树中
        if (node?.Left is not null)
        {
            predecessorNode = node.Left;
            while (predecessorNode?.Right is not null)
            {
                predecessorNode = predecessorNode.Right;
            }

            return predecessorNode;
        }

        //从祖父节点中寻找前驱结点
        while (node?.Parent is not null && node == node.Parent.Left)
        {
            node = node.Parent;
        }

        return node?.Parent;
    }

    /// <summary>
    /// 找到某个节点的后继节点，如果没有就返回null
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public TreeNode<T>? SuccessorNode(TreeNode<T>? node)
    {
        if (node is null) return null;
        TreeNode<T>? successorNode = null;
        //后继节点在右子树中
        if (node?.Right is not null)
        {
            successorNode = node.Right;
            while (successorNode.Left is not null)
            {
                successorNode = successorNode.Left;
            }

            return successorNode;
        }

        //从祖父节点中寻找后继结点
        while (node?.Parent is not null && node == node.Parent.Right)
        {
            node = node.Parent;
        }

        return node?.Parent;
    }

    #region 遍历二叉树

    public List<T> PreOrderTraversal()
    {
        List<T> result = new List<T>();
        if (_root == null) return result;
        Stack<TreeNode<T>?> stack = new Stack<TreeNode<T>?>();
        stack.Push(_root);
        while (stack.Count > 0)
        {
            TreeNode<T>? node = stack.Pop();
            result.Add(node!.Value);
            if (node.Right != null!) stack.Push(node.Right);
            if (node.Left != null!) stack.Push(node.Left);
        }

        return result;
    }

    public List<T> InOrderTraversal()
    {
        List<T> result = new List<T>();
        if (_root == null) return result;
        Stack<TreeNode<T>?> stack = new Stack<TreeNode<T>?>();
        stack.Push(_root);
        bool goLeft = true;
        while (stack.Count > 0)
        {
            TreeNode<T>? node = stack.Pop()!;
            if (node.Left == null!) goLeft = false;
            if (goLeft)
            {
                stack.Push(node);
                stack.Push(node.Left);
                continue;
            }

            result.Add(node.Value);
            if (node.Right != null!)
            {
                goLeft = true;
                stack.Push(node.Right);
            }
        }

        return result;
    }

    [Obsolete]
    public static List<T> PostOrderTraversal(TreeNode<T>? root)
    {
        throw new NotImplementedException();
        List<T> result = new List<T>();
        if (root == null) return result;
        Stack<TreeNode<T>?> stack = new Stack<TreeNode<T>?>();
        stack.Push(root);
        bool search = true;
        while (stack.Count > 0)
        {
            TreeNode<T> node = stack.Pop()!;
            if (node.Left == null! && node.Right == null!) search = false;
            if (node.Left != null! && node.Right != null!) search = true;
            if (search)
            {
                stack.Push(node);
                if (node.Left != null!)
                {
                    stack.Push(node.Left);
                    continue;
                }

                if (node.Right != null!)
                {
                    stack.Push(node.Right);
                    continue;
                }
            }

            result.Add(node.Value);
        }

        return result;
    }

    #endregion


    public IEnumerator<T> GetEnumerator()
    {
        return new BinaryTreeEnumerator<T>(this);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('[');
        if (_root == null) return "[]";
        Queue<TreeNode<T>?> queue = new Queue<TreeNode<T>?>();
        queue.Enqueue(_root!);
        int level = 1;
        int heigh = 0;
        while (queue.Count != 0)
        {
            TreeNode<T>? node = queue.Dequeue();
            level--;

            if (node is not null)
            {
                sb.Append(node.Value).Append(',');
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
            else
            {
                sb.Append("null,");
            }

            if (level == 0)
            {
                heigh++;
                if (heigh == (_root.Height))
                {
                    break;
                }

                level = queue.Count;
            }
        }

        sb[^1] = ']';
        return sb + " Height:" + heigh;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    internal sealed class BinaryTreeEnumerator<T>:IEnumerator<T>
    {
        private readonly BinaryTree<T> _binaryTree;
        private TreeNode<T>? _currentNode;
        private int _index;

        public BinaryTreeEnumerator(BinaryTree<T> binaryTree)
        {
            if (binaryTree is null)
            {
                throw new ArgumentNullException(nameof(binaryTree));
            }
            _binaryTree = binaryTree;
            CurrentMoveToFirst();
            
        }
        public bool MoveNext()
        {
            bool hasNext = _binaryTree.SuccessorNode(_currentNode) is not null;
            if (hasNext && _index !=0)
            {
                _currentNode = _binaryTree.SuccessorNode(_currentNode);
            }
            _index++;
            return hasNext;
        }

        public void Reset()
        {
            CurrentMoveToFirst();
        }

        public T Current {
            get
            {
                if (_currentNode is null) throw new InvalidOperationException();
                return _currentNode.Value;
            }

        }

        object IEnumerator.Current => Current;
        
        public void Dispose()
        {
        }

        private void CurrentMoveToFirst()
        {
            _index = 0;
            TreeNode<T>? predecessorNode = _binaryTree.Root;
            while (predecessorNode != null)
            {
                _currentNode = predecessorNode;
                predecessorNode = _binaryTree.PredecessorNode(predecessorNode);
            }
        }
    }

    /// <summary>
    /// 用层序遍历创建一棵完全二叉树,返回树的跟节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns>树的根节点</returns>
    public static TreeNode<T>? CreateTree<T>(T[] list)
    {
        if (list.Length == 0 || list == null!)
        {
            return null;
        }

        int i = 0;
        TreeNode<T> root = new TreeNode<T>(value: list[i++], parent: null!);
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

        queue.Enqueue(root);
        for (int j = i; j < list.Length; j += 2)
        {
            TreeNode<T> treeNode = queue.Dequeue();


            treeNode.Left = new TreeNode<T>(list[j], treeNode);
            queue.Enqueue(treeNode.Left);
            if (j + 1 < list.Length)
            {
                treeNode.Right = new TreeNode<T>(list[j + 1], treeNode);
                queue.Enqueue(treeNode.Right);
            }
        }

        return root;
    }
}

public class TreeNode<T>
{
    public T Value;
    public TreeNode<T> Left;
    public TreeNode<T> Right;
    public TreeNode<T> Parent;
    
    public virtual int Height
    {
        get
        {
            return GetHeight(this);
        }
        set
        {
            
        }
    }

    public bool IsLeaf => Left == null! && Right == null!;
    public bool HasTwoChildren => Left != null! && Right != null!;

    private int GetHeight(TreeNode<T> treeNode)
    {
        if (treeNode == null!) return 0;
        return Math.Max(GetHeight(treeNode.Left), GetHeight(treeNode.Right)) + 1;
    }
    public TreeNode(T value, TreeNode<T> parent)
    {
        Value = value;
        Parent = parent;
    }
}