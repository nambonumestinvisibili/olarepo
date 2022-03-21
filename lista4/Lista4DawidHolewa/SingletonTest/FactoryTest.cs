using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Lista4DawidHolewa;
using System.Diagnostics;

namespace Lista4DawidHolewaTests
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void Test1()
        {
            OpenFactory shapeFactory = new OpenFactory();
            IShapeFactoryWorker squareWorker = new SquareWorker();
            shapeFactory.RegisterWorker(squareWorker);

            var square = shapeFactory.CreateShape("square", 1);
            Assert.IsInstanceOfType(square, typeof(Square));
            Debug.WriteLine("hej");

            IShapeFactoryWorker rectWorker = new RectangleWorker();
            shapeFactory.RegisterWorker(rectWorker);

            var rect = shapeFactory.CreateShape("rectangle", 1, 2);
            Assert.IsInstanceOfType(rect, typeof(Rectangle));

        }
    }
}
