using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Rectangle : IShape
    {

        public double Length { get; set; }

        public double Width { get; set; }

        public int Sides => 4;

        public double CalculateArea() => Length * Width;
 
    }
}
