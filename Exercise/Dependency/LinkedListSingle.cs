using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace Function.Dependency
{
    public class LinkedArrayListSingle<T> : IArrayList<T>
    {
        private int _count;
        private Node<T> first;
        private Node<T> last;

        public LinkedArrayListSingle()
        {
            _count = 0;
            first = null;
            last = null;
        }
        private class Node<T>
        {
            public Node<T> prev;
            public Node<T> next;
            public T value;
            public Node(Node<T> prev , T value ,Node<T> next)
            {
                this.prev = prev;
                this.next = next;
                this.value = value;
            }
        }

        public void Clear()
        {
            first = null;
            last = null;
            _count = 0;
        }
        
        public int Count
        {
            get
            {
                return _count;
            }
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool Contains(T element)
        {
            if (first == null)
            {
                return false;
            }
            else
            {
                Node<T> node = first;
                while (node.next != null)
                {
                    if(Equals(node.value,element)){return true;}
                    node = node.next;
                }
                return false;
            }
        }

        public void Add(T element)
        {
            _count++;
            if (last == null)
            {
                last = new Node<T>(null,element,null);
                first = last;
            }
            else
            {
                Node<T> oldLastNode = last;
                last = new Node<T>(oldLastNode,element,null);
                oldLastNode.next = last;
            }
        }

        public T this[int index]
        {
            get
            {
                Node<T> node = getNode(index);
                return node.value;
            }
            set
            { 
                Node<T> node = getNode(index);
                node.value = value;
            }
        }

        public void Insert(int index, T element)
        {
            RangeCheckForAdd(index);
            Node<T> node = getNode(index);
            if (index == _count-1)
            {
                this.Add(element);
                return;
            }
            if (index == 0)
            {
                first = new Node<T>(null, element, node);
                node.prev = first;
                _count++;
                return;
            }
            Node<T> newNode = new Node<T>(node.prev, element, node);
            node.prev = newNode;
            newNode.prev.next = newNode;
            _count++;

        }

        public T Remove(int index)
        {
            RangeCheck(index);
            Node<T> node = getNode(index);
            T oldValue = node.value;
            if (index == 0)
            {
                first = node.next;
                node.next.prev = null;
                _count--;
                return oldValue;
            }
            if (index == _count -1)
            {
                last = node.prev;
                node.prev.next = null;
                _count--;
                return oldValue;
            }
            node.prev.next = node.next;
            node.next.prev = node.prev;
            _count--;
            return oldValue;
        }
        /// <summary>
        /// Use to find whether there is an element in the array,if not return -1
        /// </summary>
        /// <param name="element"></param>
        /// <returns>The position of the element</returns>
        public int IndexOf(T element)
        {
            if (_count == 0)
            {
                return -1;
            }
            else
            {
                Node<T> node = first;
                int count = 0;
                while (node != null)
                {
                    if (Equals(node.value,element))
                    {
                        return count;
                    }
                    node = node.next;
                    count++;
                }

                return -1;
            }
        }

        private void RangeCheckForAdd(int x)
        {
            if (x < 0 || x > _count)
            {
                throw new IndexOutOfRangeException($"Add:\tCount:{_count}\tPosition:{x}");
            }
        }
        private void RangeCheck(int x)
        {
            if (x < 0 || x >= _count)
            {
                throw new IndexOutOfRangeException($"Seek:\tCount:{_count}\tPosition:{x}");
            }
        }

        public override string ToString()
        {
            if (first == null)
            {
                return "null";
            }
            else
            {
                StringBuilder result = new StringBuilder();
                result.Append('[');
                Node<T> node = first;
                while (node != null)
                {
                    result.Append($"{node.value},");
                    node = node.next;
                }
                result.Remove(result.Length - 1, 1);
                result.Append(']');
                return result.ToString();
            }
        }

        private Node<T> getNode(int index)
        {
            RangeCheck(index);
            Node<T> node = null; 
            if (index < (_count >> 1))//find form the first node
            {
                node = first;
                for (int i = 0; i < index; i++)
                {
                    node = node.next;
                }
            }
            else//index > _count/2 find from the last node
            {
                node = last;
                for (int i = _count - 1; i > index; i--)
                {
                    node = node.prev;
                }
            }
            return node;
        }
    }

    public interface IArrayList<T>
    {
        void Clear();
        public int Count { get;}
        bool IsEmpty();
        bool Contains(T element);
        void Add(T element);

        public T this[int index]
        {
            get;
            set;
        }
        void Insert(int index, T element);
        T Remove(int index);
        int IndexOf(T element);
    }
}