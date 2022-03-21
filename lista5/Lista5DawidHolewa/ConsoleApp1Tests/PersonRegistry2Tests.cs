using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class PersonRegistry2Tests
    {
        [TestMethod()]
        public void PersonRegistry2Test()
        {
            PersonRegistry2 pr2 = new SmsPersonRegistry(new ConcretePersonGetter());
            pr2.Notify();
            Assert.IsTrue(true);
        }

    }
}