using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class QueueStack
    {
        private Queue<int> _queue;
        private bool IsEmpty => _queue.Count == 0;

        public QueueStack(int capacity)
        {
            _queue = new Queue<int>(capacity);
        }

        public void Push(int value)
        {
            _queue.Enqueue(value);
            while (_queue.Peek() != value)
            {
                var temp = _queue.Dequeue();
                _queue.Enqueue(temp);
            }
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                return int.MinValue;
            }
            return _queue.Dequeue();
        }
    }
}
