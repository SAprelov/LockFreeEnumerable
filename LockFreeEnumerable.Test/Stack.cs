using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void CanPush()
        {
            var value = 1;
            var stack = new LFStack<object>();
            stack.Push(value);
            Assert.AreEqual(value, stack.Pop());
        }

    }
}
