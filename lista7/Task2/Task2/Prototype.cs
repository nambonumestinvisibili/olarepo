using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Task2
{
    public abstract class Shape
    {
        public double X { get; set; }
        public double Y { get; set; }
        Color Color { get; set; }

        public Shape(double x, double y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
        public Shape(Shape shape)
        {
            X = shape.X;
            Y = shape.Y;
            Color = shape.Color;
        }

        public abstract ShapeId GetShapeId();

        public abstract Shape Clone();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(Rectangle rectangle) : base(rectangle)
        {
            Width = rectangle.Width;
            Height = rectangle.Height;
        }

        public Rectangle(double x, double y, Color color) : base(x, y, color)
        {

        }

        public override Shape Clone()
        {
            return new Rectangle(this);
        }

        public override ShapeId GetShapeId()
        {
            return ShapeId.Rectangle;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(Circle circle) : base(circle)
        {
            Radius = circle.Radius;
        }
        public Circle(double x, double y, Color color) : base(x, y, color)
        {

        }


        public override Shape Clone()
        {
            return new Circle(this);
        }

        public override ShapeId GetShapeId()
        {
            return ShapeId.Circle;
        }
    }

    public class Square : Shape
    {
        public double Width { get; set; }

        public Square(double x, double y, Color color) : base(x, y, color)
        {

        }
        public Square(Square square)  : base(square)
        {
            Width = square.Width;
        }
        public override Shape Clone()
        {
            return new Square(this);
        }

        public override ShapeId GetShapeId()
        {
            return ShapeId.Circle;
        }
    }

    public class PrototypeRegistry
    {
        private List<Shape> _shapes;

        public void AddItem(Shape shape)
        {
            _shapes.Add(shape);
        }

        public Shape getByShapeId(ShapeId shapeId)
        {
            foreach (var i in _shapes){
                if (i.GetShapeId() == shapeId)
                {
                    return i.Clone();
                }
            }
            throw new Exception("No such shape.");
        }
    }

    public enum ShapeId
    {
        Square,
        Rectangle,
        Circle
    }
}
