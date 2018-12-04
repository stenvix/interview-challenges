namespace DataStructures.Stack
{
    public class TwoStacks
    {
        private int _top1End = -1;
        private int _top2End;

        private int _top1;
        private int _top2;
        private int[] _container;

        private bool IsOverflow => _top2 - _top1 == 1;
        private bool IsEmpty1 => _top1 == _top1End;
        private bool IsEmpty2 => _top2 == _top2End;

        public TwoStacks(int capacity)
        {
            _top1 = _top1End;
            _top2 = _top2End = capacity;
            _container = new int[capacity];
        }

        public void Push1(int value)
        {
            if (IsOverflow)
            {
                return;
            }

            _container[++_top1] = value;
        }

        public void Push2(int value)
        {
            if (IsOverflow)
            {
                return;
            }

            _container[--_top2] = value;
        }

        public int Pop1()
        {
            if (IsEmpty1)
            {
                return int.MinValue;
            }
            return _container[_top1--];
        }

        public int Pop2()
        {
            if (IsEmpty2)
            {
                return int.MinValue;
            }
            return _container[_top2++];
        }
    }
}
