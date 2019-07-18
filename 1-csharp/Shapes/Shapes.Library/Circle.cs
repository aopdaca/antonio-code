using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Circle : IShape
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Circle can not have negative radius");
                }
                radius = value;
            }

        }
        public int Sides => 1;
        
        //c# prevent method overriding by default, use "virtual"

        public virtual double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
