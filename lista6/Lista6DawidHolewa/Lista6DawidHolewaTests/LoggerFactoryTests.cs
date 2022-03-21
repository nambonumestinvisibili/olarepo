using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lista6DawidHolewa;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lista6DawidHolewa.Tests
{
    [TestClass()]
    public class LoggerFactoryTests
    {
        [TestMethod()]
        public void NullLoggerTest()
        {
            Helper(LogType.None);
            //need to check std output
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ConsoleLoggerTest()
        {
            Helper(LogType.Console);
            //need to check std output
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void FileLoggerWrite()
        {
            var lf = LoggerFactory.GetInstance();
            var logger = lf.GetLogger(LogType.File, "loggerData.txt");
            logger.Log("sth");

        }


        [TestMethod()]
        public void FileLoggerRead()
        {
            StreamReader sr = new StreamReader("loggerData.txt");
            Assert.AreEqual("sth", sr.ReadLine());

        }

        private void Helper(LogType logType)
        {
            var lf = LoggerFactory.GetInstance();
            var logger = lf.GetLogger(logType);
            logger.Log("sth");

            
        }
    }
}