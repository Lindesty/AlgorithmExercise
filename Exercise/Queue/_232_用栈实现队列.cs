namespace Function.Queue
{
    namespace _232_用栈实现队列
    {
        public class MyQueue
        {
            private Stack<int> _inStack = new Stack<int>();
            private Stack<int> _outStack = new Stack<int>();
            public MyQueue()
            {

            }
            //入队
            public void Push(int x)
            {
                _inStack.Push(x);
            }
            // 出队
            public int Pop()
            {
                CheckOutStack();
                return _outStack.Pop();
            }
            // 获取队头元素
            public int Peek()
            {
                CheckOutStack();
                return _outStack.Peek();
            }
            // 队伍是否为空
            public bool Empty()
            {
                return (_inStack.Count + _outStack.Count) == 0;
            }

            private void CheckOutStack()
            {
                if (_outStack.Count == 0)
                {
                    while (_inStack.Count != 0)
                    {
                        _outStack.Push(_inStack.Pop());
                    }

                }
            }
        }
    }
}
//Your MyQueue object will be instantiated and called as such:
//MyQueue obj = new MyQueue();
//obj.Push(x);
//int param_2 = obj.Pop();
//int param_3 = obj.Peek();
//bool param_4 = obj.Empty();