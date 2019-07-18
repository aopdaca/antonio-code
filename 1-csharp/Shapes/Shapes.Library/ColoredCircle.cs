using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class ColoredCircle : Circle
    {
        public String Color
        {
            get;
            set;
        }


        //overridde on the derived class's method will replace parent class impemention of method
        //proper way to method override
        public override double CalculateArea()
        {
            Console.WriteLine("Calculating area of a colored circle");
            //base = super
            return base.CalculateArea();
        }

        //if parent does not allow override, we can still add method with same name
        //method hidding, does not replace original on object
        //that original will run if access is through variable of type circle
        //dont do this!!!!
        public new double GetPerimeter()
            {
                return 10;
            }
        // c# perfecrs composition over inharitance
        //if inharet, prefers ectenstion over modifiation
    }
}
