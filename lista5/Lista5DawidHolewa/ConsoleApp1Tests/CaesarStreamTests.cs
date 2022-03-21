using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class CaesarStreamTests

    {
        private string words = "abcdefghijk ABCDEFGH";

        [TestMethod()]
        public void WriteTest()
        {
            FileStream createdFile = File.Create("data");
            CaesarStream caesarStream = new CaesarStream(createdFile, 10);

            byte[] wordsBytes = Encoding.ASCII.GetBytes(words);
            caesarStream.Write(wordsBytes, 0, wordsBytes.Length);
            caesarStream.Close();

            
        }

        [TestMethod()]
        public void ReadTest()
        {
            FileStream fop = File.Open("data", FileMode.Open);
            CaesarStream caesarStream2 = new CaesarStream(fop, -10);
            int bufferLength = 20;
            byte[] readBytes = new byte[bufferLength];

            int bytesRead = caesarStream2.Read(readBytes, 0, bufferLength);
            string comeBack = Encoding.ASCII.GetString(readBytes);

            Assert.AreEqual(words, comeBack);
        }        
    }
}