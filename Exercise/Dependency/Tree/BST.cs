using System.Collections;
using Function.BinaryTree;
using System.Runtime.InteropServices;
using System.Text;

namespace Function.Dependency.Tree
{
    public class BST<T> : BinaryTree<T>, BinaryTreeInfo
    {
        public BST(IComparer<T>? comparator) : base()
        {
            _size = 0;
            _comparator = comparator!;
        }

        public BST() : this(null)
        {
        }

        private readonly IComparer<T> _comparator;

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Clear()
        {
            _root = null;
            _size = 0;
        }

        /// <summary>
        /// 返回数值比较结果，
        /// e1 > e2    返回值 > 0
        /// e1 = e2    返回值 = 0
        /// e1 > e2    返回值 < 0
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        private int Compare(T e1, T e2)
        {
            if (_comparator != null!)
            {
                return _comparator.Compare(e1, e2);
            }

            return e1!.GetHashCode() - e2!.GetHashCode();
        }

        /// <summary>
        /// 将大的值放在树的右边->
        /// 将小的值放在树的左边<-
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            ElementNotNullCheck(element);
            if (_root == null)
            {
                _root = CreateNode(element, null!);
                _size++;
                AfterAdd(_root);
                return;
            }

            int cmp = 0;
            TreeNode<T> currentTreeNode = _root;
            TreeNode<T> parentNode = _root;
            while (currentTreeNode != null)
            {
                cmp = Compare(currentTreeNode.Value, element);
                parentNode = currentTreeNode;
                if (cmp < 0) // currentTreeNode.Value < element
                {
                    currentTreeNode = currentTreeNode.Right;
                }
                else if (cmp == 0)
                {
                    currentTreeNode.Value = element;
                    return;
                }
                else
                {
                    currentTreeNode = currentTreeNode.Left;
                }
            }

            TreeNode<T> newNode = CreateNode(element, parentNode);
            if (cmp < 0)
            {
                parentNode.Right = newNode;
            }
            else
            {
                parentNode.Left = newNode;
            }
            AfterAdd(newNode);
            _size++;
        }

        public void Remove(T element)
        {
            _size--;
            TreeNode<T> node = GetNode(element);
            if (node == null!) return;
            if (node!.HasTwoChildren) //处理度为2的节点，将要删除的node变为删除度<2的节点
            {
                //找到后继节点
                TreeNode<T> successorNode = SuccessorNode(node)!;
                //用后继节点的值区覆盖要被删除节点的值
                node.Value = successorNode.Value;
                //要删除后继节点
                node = successorNode;
            }

            //处理删除度为1或2的节点，删除node
            TreeNode<T>? replacementNode = node.Left ?? node.Right;
            if (replacementNode != null!) //度为1的节点(可能有root节点)
            {
                replacementNode.Parent = node.Parent;
                if (node.Parent == null!) //度为1的跟节点
                {
                    _root = replacementNode;
                    _root.Parent = null!;
                }
                else //不是根节点
                {
                    if (node.Parent.Left == node) //是左子树
                    {
                        node.Parent.Left = replacementNode;
                    }
                    else //要删除的是右子树
                    {
                        node.Parent.Right = replacementNode;
                    }
                }
            }
            else if (node.Parent == null!) //删除度为0的根节点
            {
                _root = null;
            }
            else //删除叶子节点,不是根节点
            {
                if (node.Parent.Left == node) //node是左子节点
                {
                    node.Parent.Left = null!;
                }
                else //node是右子节点
                {
                    node.Parent.Right = null!;
                }
            }


            //要删除的节点是叶子结点,子节点数量为0
            // if (node.IsLeaf)
            // {
            //     //叶子结点有父节点
            //     if (node.Parent.Left == node)
            //     {
            //         node.Parent.Left = null!;
            //     }
            //
            //     if (node.Parent.Right == node)
            //     {
            //         node.Parent.Right = null!;
            //     }
            //
            //     // 整颗树只有一个节点
            //     if (node?.Parent is null)
            //     {
            //         _root = null!;
            //     }
            // } //删除度为一的子节点，子节点数量为1
            // //               6      
            // //              / \
            // //             2   8
            // //              \   \
            // //               4   9
            // //              / \
            // //             3   5
            // // 
            // else
            // {
            //     if (node == node?.Parent.Left)
            //     {
            //         TreeNode<T>? replacementNode = (node?.Left is null ? node?.Right : node.Left);
            //         node!.Parent.Left = replacementNode!;
            //         replacementNode!.Parent = node.Parent;
            //     }
            //
            //     if (node == node?.Parent.Right)
            //     {
            //         TreeNode<T>? child = (node?.Left is null ? node?.Right : node.Left);
            //         node!.Parent.Right = child!;
            //         child!.Parent = node.Parent;
            //     }
            //
            //     //删除的是根节点
            //     if (node == _root)
            //     {
            //         TreeNode<T>? child = (node?.Left is null ? node?.Right : node.Left);
            //         _root = child;
            //         child!.Parent = null!;
            //     }
            // }
        }

        public TreeNode<T> GetNode(T element)
        {
            if (_root is null)
            {
                return null!;
            }

            TreeNode<T> node = _root;
            while (node is not null)
            {
                int cmp = Compare(element, node.Value);
                if (cmp == 0)
                {
                    break;
                }
                else if (cmp > 0) //element > node.Value 向右边查找
                {
                    node = node.Right;
                }
                else
                {
                    node = node.Left;
                }
            }

            return node!;
        }

        public bool Contains(T element)
        {
            TreeNode<T> currentTreeNode = _root!;
            while (currentTreeNode != null)
            {
                var cmp = Compare(currentTreeNode.Value, element);
                if (cmp == 0)
                {
                    return true;
                }
                else if (cmp < 0)
                {
                    currentTreeNode = currentTreeNode.Right;
                }
                else
                {
                    currentTreeNode = currentTreeNode.Left;
                }
            }

            return false;
        }

        /// <summary>
        /// 添加节点后的操作
        /// </summary>
        /// <param name="newNode"></param>
        protected virtual void AfterAdd(TreeNode<T> newNode)
        {

        }

        protected virtual TreeNode<T> CreateNode(T value, TreeNode<T> parent)
        {
            return new TreeNode<T>(value, parent);
        }
        private void ElementNotNullCheck(T element)
        {
            if (element == null)
            {
                throw new ArgumentException("Element must not be null!");
            }
        }

        object BinaryTreeInfo.Root()
        {
            return _root;
        }

        public object Left(object node)
        {
            return ((TreeNode<T>) node).Left;
        }

        public object Right(object node)
        {
            return ((TreeNode<T>) node).Right;
        }

        public string GetString(object node)
        {
            return ((TreeNode<T>) node).Value.ToString();
        }
    }
}