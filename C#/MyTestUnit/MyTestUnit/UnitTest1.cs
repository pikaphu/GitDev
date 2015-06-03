using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }

        [TestMethod]
        public void TestMethod2(int val1)
        {
            if (val1 < 0)
            {
                throw new ArgumentException("value cannot less than zero");
            }
        }
    }
}
