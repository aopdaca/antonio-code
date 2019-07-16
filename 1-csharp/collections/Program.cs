using System;
using System.Collections;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Arrays();
            // Lists();
            Others();
        }

        static void Arrays()
        {
            int[] intArray = new int[3];
            intArray[0] = 3;
            intArray[1] = 4;
            Print(intArray);

            bool done = false;
            int length = 0;
            while (!done)
            {
                Console.WriteLine("Please enter a length");
                String lengthStr = Console.ReadLine();

                try
                {
                    length = int.Parse(lengthStr);
                    done = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input " + lengthStr + " try again");
                }
            }
            int[] unknownLength = new int[length];

            //jagged arrays
            string[][] twoDString = new string[2][];
            twoDString[0] = new string[2];
            twoDString[1] = new string[5];

            //multi-dimensional arrays
            //3d boot array
            bool[,,] threeDBool = new bool[3,3,4];
            threeDBool[0, 0, 0] = true;


            Print(unknownLength);
        }

        static void Lists(){
            
            ArrayList list = new ArrayList();
            
            list.Add(3);
            list.Add(3);
            list.Add(3);
            list.Add(true);

            list.RemoveAt(0);

            int item = (int) list[1];

            

            Print(list);


            var goodList = new List<bool>();

            goodList.Add(false);
            // goodList.Add(3);

            var ints = new int[] {1,2,3,4,5};

            var initList = new List<int> {1 , 2, 3, 4, 5};
        }
        
        static void Others(){
            var set = new HashSet<string>();
            //know when to use set or list

            var dic = new Dictionary<string, int>();

            dic["laptop"] = 2;
            dic["cup"] = 1;
            dic["marker"] = 5;
        }

        static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Print(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
