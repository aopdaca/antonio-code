using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Variables");
            String s = "Antonio";
            bool b = true;
            int i = 5;
            s = "Garcia";
            b = false;
            i = 1;

            Console.WriteLine(s);
            Console.WriteLine(b);
            Console.WriteLine(i);

            Console.WriteLine();
            Console.WriteLine("For Loop");
            for (int j = 9; j >= 6; j--)
            {
                Console.WriteLine(j);
            }
            int k = 5;
            Console.WriteLine();
            Console.WriteLine("While Loop");
            while (i < k)
            {
                Console.WriteLine(k);
                k--;
            }

            int caseSwitch = 11;
            Console.WriteLine();
            Console.WriteLine("Switch Case");
            switch (caseSwitch)
            {
                case 10:
                    Console.WriteLine("Case 10");
                    break;
                case 20:
                    Console.WriteLine("Case 20");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("If, Else If, Else");
            int ifex = 7;
            if (ifex < 8)
            {
                Console.WriteLine("greater than 8");
            }
            else if (ifex > 6)
            {
                Console.WriteLine("less than 6");
            }
            else
            {
                Console.WriteLine("number is less than 8 but greater than 6");
            }

            /*This is a Multi-line
            comment because i like to use up space for no reason */

            // shift-alt-f for formating your vsc properly

            Console.WriteLine();
            Console.WriteLine("Static method");
            helloworld();

            /* variables that are declared at method scope can have an implicit "type" var. An implicitly typed local variable is strongly typed just as if you had declared the type yourself, 
            but the compiler determines the type. The following two declarations of i are functionally equivalent: 
            var i = 10; // Implicitly typed.
            int i = 10; // Explicitly typed.
            compile time inferance
            */

        }

        public static void helloworld()
        {
            Console.WriteLine("you have called hello world");
        }

        
    }
}
