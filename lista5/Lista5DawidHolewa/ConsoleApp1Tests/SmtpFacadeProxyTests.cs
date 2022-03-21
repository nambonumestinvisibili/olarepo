using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class SmtpFacadeProxyTests
    {
        [TestMethod()]
        public void SmtpFacadeProxyTest()
        {
            //past 22
            Assert.ThrowsException<Exception>(() =>
            {
                SmtpFacadeProxy fp = new SmtpFacadeProxy();
                fp.Send("a", "a", "v", "c", null, "aa", "aa");
            });
        }

        [TestMethod()]
        public void LoggingTest()
        {
            //need to look at additional out data
            SmtpFacadeLoggingProxy lp = new SmtpFacadeLoggingProxy();
            lp.Send("a", "b", "c", "d", null, "a", "a");
            Assert.IsTrue(true);
        }
    }
}