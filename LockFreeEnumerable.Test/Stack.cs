using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LockFreeEnumerable.Test
{
    [TestClass]
    public class Stack
    {
        [TestMethod]
        public void CanCreate()
        {
            var stack = new LFStack<object>();
            Assert.IsNotNull(stack);
        }

        [TestMethod]
        public void CanPushAndPop()
        {
            const int value = 1;
            var stack = new LFStack<object>();
            stack.Push(value);
            Assert.AreEqual(value, stack.Pop());
        }

        [TestMethod]
        public void CanParrallelPush()
        {
            const int count = 10000;
            var stack = new LFStack<object>();
            Parallel.For(0, count,  i => stack.Push(i));
            for (var i = 0; i < count; i++)
            {
                Assert.IsNotNull(stack.Pop());
            }
        }

        [TestMethod]
        public void CanParrallelPop()
        {
            const int count = 10000;
            var stack = new LFStack<object>();
            Parallel.For(0, count, i => stack.Push(i));
            Parallel.For(0, count, i => Assert.IsNotNull(stack.Pop()));
            Assert.IsNull(stack.Pop());
        }
    }
}