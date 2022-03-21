using Lista4DawidHolewa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace SingletonTest
{
    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        public void ShouldReferenceTheSameObject()
        {
            Singleton s = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            Assert.AreEqual(s, s2);
        }

        [TestMethod]
        public void ShouldReferenceDifferentObjects()
        {
            ThreadSingleton s = null;
            ThreadSingleton s2 = null;
            
            Thread t1 = new Thread(() => {
                s = ThreadSingleton.Instance;
            });
            Thread t2 = new Thread(() => {
                s2 = ThreadSingleton.Instance;
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Assert.AreNotEqual(s, s2);

        }

        [TestMethod]
        public void ShouldReferenceTheSameObjects1AndDifferentObjects23()
        {
            Singleton5sec s1 = Singleton5sec.Instance();
            Thread.Sleep(4000);
            Singleton5sec s2 = Singleton5sec.Instance();
            Thread.Sleep(2000);
            Singleton5sec s3 = Singleton5sec.Instance();

            Assert.AreEqual(s1, s2);
            Assert.AreNotEqual(s1, s3);
            Assert.AreNotEqual(s2, s3);
        }
    }
}
