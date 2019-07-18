using System;
using Shapes.Library;

namespace Shapes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle();
            circle.Radius = 4;

            var circle2 = new Circle
            {
                Radius = 4
            };

            PrintCircleDetails(circle);

            var rect = new Rectangle
            {
                Length = 5,
                Width = 3
            };

            PrintShapeDetails(circle);
            PrintShapeDetails(rect);

            var blackCircle = new ColoredCircle
            {
                Radius = 5,
                Color = "Black"
            };
            PrintCircleDetails(blackCircle);

            //upcasting
            Circle circle3 = blackCircle;

            //circle3.Color; ERROR

            var x = blackCircle.Color;

            ColoredCircle y = (ColoredCircle)circle3;

        }

        static void PrintCircleDetails(Circle circle)
        {
            Console.WriteLine($"Radius: {circle.Radius}");
        }

        static void PrintShapeDetails(IShape shape)
        {
            //Circle circle = (Circle)shape; throws invalidcastexception when a rectangle is passed
            //downcasting can fail
            Console.WriteLine($"Sides: {shape.Sides}");
            Console.WriteLine($"Area: {shape.Sides}");
        }

        static void NumericCasting()
        {
            int num = 6;
            double num2 = num; //safe - can not lose any info
            int num3 = (int)num2; //double to int unsafe could lose info.Must be explicit cast.
        }
    }
}
