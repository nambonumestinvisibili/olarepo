using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class PersonRegistryTests
    {
        [TestMethod()]
        public void PersonRegistryTest()
        {
            PersonRegistry pr = new XmlPersonRegistry(new ConcretePersonNotifier());
            pr.NotifyPersons();
            //have to look into additional out data: two notifies
            Assert.IsTrue(true);
        }

    }
}