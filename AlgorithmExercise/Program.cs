using System;
using System.Collections.Generic;
using System.Linq;
using Function.BinaryTree;
using Function.Dependency;
using Function.LinkedList;
using Function.Stack;
using Function.Queue;
using Function.Queue._232_用栈实现队列;
using TreeNode = Function.Dependency.TreeNode;
using Function.Dependency.Tree;

namespace AlgorithmExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test22();
        }

        public static void Test01()
        {
            ListNode head = new ListNode(2);
            ListNode _2 = new ListNode(5);
            ListNode _3 = new ListNode(2);
            ListNode _4 = new ListNode(1);
            ListNode _5 = new ListNode(7);
            ListNode _6 = new ListNode(7);
            ListNode _7 = new ListNode(3);
            head.next = _2;
            _2.next = _3;
            _3.next = _4;
            _4.next = _5;
            _5.next = _6;
            _6.next = _7;


            Common.Show(head);
            //[2,5,2,1,7,7,3,]
            head = _206_反转链表.ReverseListByRecursion(head);
            //[3,7,7,1,2,5,2,]
            Common.Show(head);
            Console.WriteLine(_876_链表的中间结点.MiddleNode2(head).val);
            Common.Show(_83_删除排序链表中的重复元素.DeleteDuplicates(head));
            Common.Show(_203_移除链表元素.RemoveElements(head, 7));

            Console.WriteLine("---------------------------Dividing Line-----------------------------");
        }

        public static void Test02()
        {
            Function.Dependency.IArrayList<int> Array = new Function.Dependency.MyLinkedArrayList<int>();
            Array.Add(3);
            Array.Add(0);
            Array.Add(5);
            Array.Add(4);
            Array.Add(9);
            Array.Add(8);
            //[3,0,5,4,9,8]
            Console.WriteLine(Array[0]); //3
            Console.WriteLine(Array[5]); //8
            Array[0] = 20;
            Array[5] = 15;
            Console.WriteLine(Array); //[20,0,5,4,9,15]
            Array.Remove(0);
            Console.WriteLine(Array); //[0,5,4,9,15]
            Array.Remove(4);
            Console.WriteLine(Array); //[0,5,4,9]
            Array.Remove(2);
            Console.WriteLine("-------------insert-------------");
            Console.WriteLine(Array); //[0,5,9]
            Array.Insert(1, 8);
            Console.WriteLine(Array); //[0,8,5,9]
            Array.Insert(0, 2);
            Console.WriteLine(Array); //[2,0,8,5,9]
            Array.Insert(4, 8);
            Console.WriteLine(Array); //[2,0,8,5,9,8]
            Console.WriteLine(Array.Count);

            Console.WriteLine(Array.IndexOf(8));
            Console.WriteLine(Array.Count); //6
            Console.WriteLine(Array);
            Console.WriteLine("----------------------DividingLine--------------------------");
        }

        public static void Test03() //_20_有效的括号
        {
            _20_有效的括号 program = new _20_有效的括号();
            Console.WriteLine(program.IsValid("[{()}]"));
            Console.WriteLine(program.IsValid("()"));
            Console.WriteLine(program.IsValid("()[]{}"));
            Console.WriteLine(program.IsValid("(]"));
            Console.WriteLine(program.IsValid("{[]}"));
        }

        public static void Test04()
        {
            Console.WriteLine("----------------------DividingLine--------------------------");
            MyQueue myQueue = new MyQueue();
            myQueue.Push(11);
            myQueue.Push(22);
            myQueue.Push(33);
            myQueue.Push(44);
            myQueue.Pop();
            myQueue.Push(55);
            myQueue.Push(66);

            while (!myQueue.Empty())
            {
                Console.WriteLine(myQueue.Pop());
            }

            Console.WriteLine(myQueue.Empty());
        }

        public static void Test05()
        {
            _856_括号的分数 myMethod = new _856_括号的分数();
            Console.WriteLine(myMethod.ScoreOfParentheses("()")); //1
            Console.WriteLine(myMethod.ScoreOfParentheses("(())")); //2
            Console.WriteLine(myMethod.ScoreOfParentheses("()()")); //2
            Console.WriteLine(myMethod.ScoreOfParentheses("(()(()))")); //6
            Console.WriteLine(myMethod.ScoreOfParentheses("(())()")); //3
        }

        /// <summary>
        /// 二叉搜索树
        /// </summary>
        public static void Test06()
        {
            BST<int> set = new BST<int>();
            foreach (int i in new int[] {50, 25, 75, 12, 36, 64, 88})
            {
                set.Add(i);
            }

            var root = BinaryTree<int>.CreateTree(new int[] {50, 25, 75, 12, 36, 64, 88});
            _226_翻转二叉树.InvertTree(set.Root!);
            Console.WriteLine(set.Root!);
            Console.WriteLine(root!);
            List<int> list = new List<int>() {0, 1, 2, 3, 4};
            int j = 0;
            Console.WriteLine(list[j++]);
            Console.WriteLine(list[j]);

            Console.ReadLine();
        }

        /// <summary>
        /// 用迭代遍历二叉树树
        /// </summary>
        public static void Test07()
        {
            List<int> integers = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            integers.ShowList();
            TreeNode<int>? rootNode = BinaryTree<int>.CreateTree(integers.ToArray());
            // ExtendMethod.PostOrderTraversal(rootNode).ShowList();
        }

        /// <summary>
        /// 二叉树的层序遍历
        /// </summary>
        public static void Test08()
        {
            _102_二叉树的层序遍历 method = new _102_二叉树的层序遍历();
            TreeNode root = ExtendMethod.CreateTreeSimple(new[] {0, 1, 2, 3, 4, 5, 6});
            Console.WriteLine(root);
            var treeList = method.LevelOrder(root);

            treeList.ShowList(list => { return list.ListToString<int>(); });


            IList<IList<int>> myArrayList = new List<IList<int>>()
            {
                new List<int>() {0},
                new List<int>() {1, 2},
                new List<int>() {3, 4, 5, 6,},
            };
            myArrayList.ShowList(list => { return list.ListToString<int>(); });
        }

        /// <summary>
        /// _106_从中序与后序遍历序列构造二叉树
        /// </summary>
        public static void Test09()
        {
            _106_从中序与后序遍历序列构造二叉树.Test();
        }

        /// <summary>
        /// 打印二叉树
        ///  </summary>
        private static void Test20()
        {
            BST<int> bst = new BST<int>();
            foreach (int i in new int[] {5, 3, 7, 2, 4, 6, 8, 1, 9})
            {
                bst.Add(i);
            }

            InOrderPrinter printer = new InOrderPrinter(bst);
            Console.WriteLine(printer.PrintString());
            Console.WriteLine(bst.Root!);
            Console.WriteLine();
        }

        /// <summary>
        /// 测试二叉树元素删除
        /// </summary>
        private static void Test21()
        {
            BST<int> bst = new BST<int>();
            var integerList = new int[] {5, 3, 7, 2, 4, 6, 8, 1, 9};
            integerList.GetEnumerator();
            foreach (int i in integerList)
            {
                bst.Add(i);
            }

            InOrderPrinter printer = new InOrderPrinter(bst);
            Console.WriteLine(printer.PrintString());
            bst.Remove(8);
            Console.WriteLine($"----------+----------");
            Console.WriteLine(printer.PrintString());
            Console.WriteLine(bst.Contains(8));
            Console.WriteLine(bst.Contains(5));
            Console.WriteLine($"----------+----------");
            bst.Add(8);
            // LevelOrderPrinter levelOrderPrinter = new LevelOrderPrinter(bst);
            // Console.WriteLine(levelOrderPrinter.printString());
            var nullableNames = new List<string?>() {"jack", null, "Tom", "marry", null, null};
            var notNullNames = nullableNames.Where(name=> name != null);    
            Console.WriteLine(notNullNames.ToList().ListToString());


            Console.WriteLine($"----------+----------");
            foreach (int i in bst)
            {
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// AVLTree
        /// </summary>
        public static void Test22()
        {
            
            AvlTree<int> tree = new AvlTree<int>(Comparer<int>.Default);
            InOrderPrinter printer = new InOrderPrinter(tree);
            
            tree.Add(0);
            tree.Add(3);
            Console.WriteLine(printer.PrintString());
            tree.Add(4);
            Console.WriteLine(printer.PrintString());
            var node = tree.GetNode(3);
            Console.WriteLine(tree.IsBalanced(node));

        }


    }
}