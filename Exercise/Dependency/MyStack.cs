using System;

namespace Function.Dependency
{
    public class MyStack<T>
    {
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
        private Node<T> head;
        //the number of elements
        private int _count;
        public int count
        {
            get
            {
                return _count;
            }
        }
        //whether it's empty
        public bool isEmpty()
        {
            return _count == 0;
        }
        public void push(T element)
        {
            if (head == null)
            {
                head = new Node<T>(null, element, null);
            }
            else
            {
                Node<T> node = head;
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = new Node<T>(node, element, null);
            }
            _count++;
        }

        public T pop()
        {
            if (head != null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Node<T> node = head;
                while (node.next != null)
                {
                    node = node.next;
                }
                T value = node.value;
                node.prev.next = null;
                return value;
            }
        }
        //get the top element
        public T peek()
        {
            if (_count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node<T> node = head;
            while (node.next != null)
            {
                node = node.next;
            }
            return node.value;
        }
    }
}