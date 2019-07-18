using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public interface IShape
    {
        int Sides
        {
            get;
        }

        double CalculateArea();
    }
}
