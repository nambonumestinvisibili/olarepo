using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lista4DawidHolewa
{
    public class OpenFactory
    {
        private List<IShapeFactoryWorker> _workers = new List<IShapeFactoryWorker>();

        public void RegisterWorker(IShapeFactoryWorker worker)
        {
            _workers.Add(worker);
        }

        public IShape CreateShape(string shapeName, params double[] parameters)
        {
            foreach (var worker in _workers)
            {

                if (worker.AcceptsParameters(shapeName, parameters))
                {
                    return worker.Produce(parameters);
                }
            }
            
            throw new Exception("No worker found for given params");
        }
    }

    public interface IShapeFactoryWorker
    {
        bool AcceptsParameters(string shapeName, params double[] parameters);
        IShape Produce(params double[] parameters);
    }

    public interface IShape
    {
    }

    public class SquareWorker : IShapeFactoryWorker
    {
        public bool AcceptsParameters(string shapeName, params double[] parameters)
        {
            return shapeName == "square" && parameters.Length == 1;
        }

        public IShape Produce(params double[] parameters)
        {
            return new Square() { Side = parameters[0] };
        }
    }

    public class RectangleWorker : IShapeFactoryWorker
    {
        public bool AcceptsParameters(string shapeName, params double[] parameters)
        {
            return shapeName.Equals("rectangle") && parameters.Length == 2;
        }

        public IShape Produce(params double[] parameters)
        {
            return new Rectangle() { SideHorizontal = parameters[0], SideVertical = parameters[1] };
        }
    }

    public class Square : IShape
    {
        private double _side;
        public double Side
        {
            get { return _side; } 
            set {
                if (value <= 0) throw new Exception("Side has to be positive");
                _side = value;
            }
        }
    }

    public class Rectangle : IShape
    {
        private double _side1;
        private double _side2;

        public double SideVertical
        {
            get { return _side1; }
            set
            {
                if (value <= 0) throw new Exception("Side has to be positive");
                _side1 = value;
            }
        }

        public double SideHorizontal
        {
            get { return _side2; }
            set
            {
                if (value <= 0) throw new Exception("Side has to be positive");
                _side2 = value;
            }
        }
    }
}
