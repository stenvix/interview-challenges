using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ListStack<T>
    {
        private LinkedList<T> _container;
        private bool IsEmpty => _container.Count == 0;

        public ListStack()
        {
            _container = new LinkedList<T>();
        }

        public void Push(T item)
        {
            _container.AddLast(item);
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new System.ArgumentNullException("Stack is empty");
            }
            var value = _container.Last;
            _container.RemoveLast();

            return value.Value;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new System.ArgumentNullException("Stack is empty");
            }
            return _container.Last.Value;
        }
    }
}
