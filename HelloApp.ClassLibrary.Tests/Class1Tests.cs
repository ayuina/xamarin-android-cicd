using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloApp.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp.ClassLibrary.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void HelloTest()
        {
            var name = "hoge";
            var message = Class1.Hello(name);
            StringAssert.Contains(message, "Hello");
            StringAssert.Contains(message, name);
        }

        [TestMethod()]
        public void HelloAnonymous()
        {
            var name = "";
            var message = Class1.Hello(name);
            StringAssert.Contains(message, "Hello");
            StringAssert.Contains(message, "Anonymous");
        }

        [TestMethod()]
        public void DummyTest_Success1()
        {
        }
        [TestMethod()]
        public void DummyTest_Success2()
        {
        }
        [TestMethod()]
        public void DummyTest1()
        {
            Assert.Inconclusive();
        }
        [TestMethod()]
        public void DummyTest2()
        {
            Assert.Inconclusive();
        }

    }
}