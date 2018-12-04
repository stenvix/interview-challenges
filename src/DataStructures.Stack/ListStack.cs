using System;

namespace DataStructures.Stack
{
    public class ListStack
    {
        private ListStackNode _root;
        public bool IsEmpty => _root == null;

        public void Push(int value)
        {
            var node = new ListStackNode { Value = value };
            if (IsEmpty)
            {
                _root = node;
            }
            else
            {
                node.Next = _root;
                _root = node;
            }

            Console.WriteLine($"Pushed {value} in list stack");
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                Console.WriteLine("List stack is empty");
                return int.MinValue;
            }

            var node = _root;
            _root = _root.Next;
            Console.WriteLine($"Popped {node.Value} from list stack");
            return node.Value;
        }

        private class ListStackNode
        {
            public int Value { get; set; }
            public ListStackNode Next { get; set; }
        }
    }
}
