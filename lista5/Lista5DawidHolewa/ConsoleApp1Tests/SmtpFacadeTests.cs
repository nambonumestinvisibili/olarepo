using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class SmtpFacadeTests
    {
        [TestMethod()]
        public void SendTest()
        {

            SmtpFacade client = new SmtpFacade();
            string passwd = "";
            string fromto = "dvwidholewv@gmail.com";
            client.Send(fromto, fromto, "Testing", "Does it work?", null, "text/plain", passwd);

        }
    }
}