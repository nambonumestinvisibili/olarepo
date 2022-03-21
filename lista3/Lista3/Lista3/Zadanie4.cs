using System;
using System.Collections.Generic;
using System.Text;

namespace Lista3
{
    class Zadanie4
    {
        // ta implementacja wprowadzi klienta w błąd, będzie on oczekiwał, że zastępując
        // Rectangle potomną Square nadal dostanie poprawny wynik 4*5 = 20
        // tymczasem Square zacieśnia warunki, (co łamie LSP) w implementacji właściwości, zastępuje jeden bok przez drugi,
        // w rezultacie otrzymuje 4*4
        // lepsza implemetacja:
        // figury potraktujemy jako równe sobie w kategoriach potomności:
        public static void Main(string[] args)
        {
            int w = 4;
            Shape rect = new Square() { Width = w };
            AreaCalculator calc = new AreaCalculator();
            Console.WriteLine("kwadrat {0}x{0} ma pole {1}",
                                w, calc.CalculateArea(rect));
        }

        public class Square : Shape
        {
            public int Width { get; set; }
            public override double Area() => Width * Width;
        }

        public class Rectangle : Shape
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public override double Area() => Width * Height;
        }
        
        public abstract class Shape
        {
            public abstract double Area();
        }


        public class AreaCalculator
        {
            public double CalculateArea(Shape polygon) => polygon.Area();
        }


    }
}
