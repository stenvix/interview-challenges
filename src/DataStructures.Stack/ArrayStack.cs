using System;

namespace DataStructures.Stack
{
    public class ArrayStack
    {
        private int _top;
        private readonly int[] _container;

        public ArrayStack(int capacity)
        {
            _top = -1;
            _container = new int[capacity];
        }

        public void Push(int value)
        {
            if (_top == _container.Length - 1)
            {
                Console.WriteLine("Stack overflow");
                return;
            }
            _container[++_top] = value;
            Console.WriteLine($"Pushed {value} in array stack");
        }

        public int Pop()
        {
            if (_top == -1)
            {
                Console.WriteLine("Stack is empty");
                return int.MinValue;
            }
            var value = _container[_top--];
            Console.WriteLine($"Popped {value} from list stack");
            return value;
        }

        public int Peek()
        {
            if (_top == -1)
            {
                Console.WriteLine("Stack is empty");
                return int.MinValue;
            }
            return _container[_top];
        }
    }
}
