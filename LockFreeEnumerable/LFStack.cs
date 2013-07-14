using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockFreeEnumerable.Test
{
    public class LFStack<T1>
    {
        private Item<T1> head;

        private struct Item<T2>
        {
            public T2 Value;
            
            public object Next;
        }

        public void Push(T1 value)
        {
            head = new Item<T1> { Value = value, Next = head };
        }

        public T1 Pop()
        {
            var pop = head;
            head = (Item<T1>)pop.Next;
            return pop.Value;
        }
    }
}
