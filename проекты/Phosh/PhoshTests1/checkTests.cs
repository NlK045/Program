using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phosh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phosh.Tests
{
    [TestClass()]
    public class checkTests
    {
        [TestMethod()]
        public void AdditionTest()
        {
            Assert.AreEqual(10, check.Addition(5, 5));
        }

        [TestMethod()]
        public void EqualityTest()
        {
            Assert.AreEqual(false, check.Equality(5, 8));
        }

        [TestMethod()]
        public void ConcatationTest()
        {
            Assert.AreEqual("500 300", check.Concatation("500", "300"));
        }
    }
}