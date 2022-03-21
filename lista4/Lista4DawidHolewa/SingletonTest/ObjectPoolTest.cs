using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Lista4DawidHolewa;

namespace Lista4DawidHolewaTests
{
    [TestClass]
    public class ObjectPoolTest
    {
        [TestMethod]
        public void InvalidCapacity()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () =>
                {
                    ObjectPool<Plane>.Discredit();
                    ObjectPool<Plane> op = ObjectPool<Plane>.Instance(0);
                }
            );
        }

        [TestMethod]
        public void ValidCapacity()
        {
            ObjectPool<Plane>.Discredit();
            var op = ObjectPool<Plane>.Instance(1);
            var plane = op.AcquireObject();
            Assert.IsNotNull(plane);
        }

        [TestMethod]
        public void CapacityDepleted()
        {
            var op = ObjectPool<Plane>.Instance(1);
            var plane = op.AcquireObject();
            Assert.ThrowsException<ArgumentException>(
                () =>
                {
                    var plane2 = op.AcquireObject();
                });
        }

        [TestMethod]
        public void ReuseObject()
        {
            var op = ObjectPool<Plane>.Instance(1);
            var plane = op.AcquireObject();
            op.ReleasePlane(plane);
            var plane2 = op.AcquireObject();
            Assert.AreEqual(plane, plane2);

        }

        [TestMethod]
        public void ReleaseInvalidObject()
        {
            var op = ObjectPool<Plane>.Instance(1);
            Plane p = new Plane();
            Assert.ThrowsException<ArgumentException>(
                () =>
                {
                    op.ReleasePlane(p);
                }
                );

        }


    }
}
