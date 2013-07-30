using System.Threading;

namespace LockFreeEnumerable
{
    public class LFStack<T1>
    {
        private Item<T1> head;

        public void Push(T1 value)
        {
            var item = new Item<T1>(value)
            {
                Next = head
            };

            while (item.Next != Interlocked.CompareExchange(ref head, item, item.Next))
            {
                item.Next = head;
            }
        }

        public T1 Pop()
        {
            if (head == null)
            {
                return default(T1);
            }
            
            var item = head;
            while (item != Interlocked.CompareExchange(ref head, item.Next, item))
            {
                item = head;
            }
            return item.Value;
        }

        private class Item<T2>
        {
            public Item<T2> Next;
            public readonly T2 Value;

            public Item(T2 value)
            {
                Value = value;
            }
        }
    }
}