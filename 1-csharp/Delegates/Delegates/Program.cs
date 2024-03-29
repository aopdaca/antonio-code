﻿using System;
using System.Collections.Generic;
using System.Linq;
using Delegates.Extenstions;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var player = new MoviePlayer
            {
                Currentmovie = new Movie
                {
                    Title = "The Lion King",
                    ReleaseDate = new DateTime(2019, 7, 19)
                }
            };

            //we are treating methods as just another form of data
            //that can be in variables etc.
            MoviePlayer.MovieEndHandlerNoParam handler = AnnounceEndOfMovie;

            MoviePlayer.MovieEndHandlerWithTitle handler2 = AnnounceEndOfMovieByName;

            Action<string> handler3 = AnnounceEndOfMovieByName;

            Action<string> handler4 = (title) => Console.WriteLine(title);

            Func<int, int, int> add = (a, b) => a + b;

            bool x = add(3, 4) == 7;

            Func<string, int> printLength = value =>
            {
                Console.WriteLine(value.Length);
                return value.Length;
            };


            //subscribe with +=
            player.MovieEnd += handler2;

            //unsubscribe with -=
            player.MovieEnd -= handler2;
            player.MovieEnd += (title) => Console.WriteLine($"(title) is over from lambda") ;

            player.Play();
        }

        static void FuncAndAction()
        {
            // these are two generic types that can represent any kind of function/method

            //Func<string>...means , zero parameters, returns string.
            //Func<int, string> - means, one int param, returns string
            //Action<String> - means, one string param, void return
            //Action<int, String> - means, two string param, void return

            //this is less cumbersome than defining delegate types
            //but its also less self-documenting 

        }


        static void AnnounceEndOfMovie()
        {
            Console.WriteLine("Movie Has Ended");
        }

        static void AnnounceEndOfMovieByName(string title)
        {
            Console.WriteLine($" {title} Movie Has Ended");
        }

        static void Linq()
        {
            //in C# we use LINQ to do a lot of operations of sequences of values
            //(arrays, lists,hashsets, or ant IEnumerable)

            //LinQ i mostly just a lot of extenstion methods defined on IEnumerable
            // from the System.Linq namespace

            //"abc".VowelCount();

            var list = new List<string>
            {
                "abc","aaa","1234", "", "arfdfdd"
            };

            //select takes one function, to map each value in the sequence to some new value
            list.Select(x => x.Length); //[3, 8, 8, 0, 8]

            //where takes one function, returning bool, to decide whether to keep the value
            list.Where(x => x[0] == 'a'); //["abc", "aaaaaaa", "aaadfa"]

            //any & all
            //take one function, retuning bool
            //checks some condition for all or for some of the sequence
            list.All(x => x != null); //true
            list.All(x => x == null); //false

            //sum can add up lists of numbers
            //or give it a function that turns each value into a number

            list.Sum(x => x.Length); //27 total length

            //similarly, we can do Min, Max, Avg

            //first gives the first element mathing condition
            list.First(x => x.Length<3); //""
            //it will throw exception if no mathces
            //we have FirstorDefult if we want it to just give null or 0 when no mathces

            //can ise count to give number of elements matching condition

            //wecan skip elements from front using skip
            list.Skip(2); //["22322", "", "asdds"] (everything but first 2)

            //take can discard extra elementssffrom end of list
            list.Take(2); //only grabs the first two elements of the list

            var abc = list.Where(x => !string.IsNullOrEmpty(x))
                           .Select(x => x[0])
                           .Reverse(); // all first characters, in revers order

            //some LINQ methods return IEnumerables (sequences)
            //these ise "defered execution. they do not loop through the sequence YET"
            //this if used right can  save resources.

            abc.First(); // only processing  the one element i need 

            // we have .ToList() and .ToArray() to convert any IEnumerable
            //this forces execution of all the prossessing right now.

            list.Zip(list, (a, b) => a + b); // ["abcabc", "aaaaaaaaa", ....]

            //foreach(var item in abc)
            //{
            //    //now the processing is done
            //}

            //we have query syntax...the other way is called "method syntax"
            var abcd = (from x in list
                       where x != null
                       select x[0]).Reverse();

            var c = 3;
            var d = 4;
            Swap(ref c, ref d);

            //now a should be 4 and b should be 3
            //ref makes this possible

            // ref lets you truly pass variables by referenced in C#

            //unsafe
            //{
            //    //unsave blocks grabage collectoe does not operate
            //    int x = 3;
            //    int* p = &x;
            //    //unsafe code allows interopablility with unmanaged code
            //    //like windows Apis and other c code
            //}
        }

        public static void OutParameters()
        {
            //out also passes variables by reference...
            //but it must be a new uninitalized variable

            var str = "1234";
            int number;
            try
            {
                number = int.Parse(str);
            }
            catch (FormatException)
            {
                Console.WriteLine("INVALID!");
            }

            //with out we can hace a method effedctively return ttow different things
            // we cant send any data INTO the method with out but we can pull data out
            if(int.TryParse(str, out int result)){
                //in here result is a int containing the valid number
            }
            else
            {
                //in here it did not parse correctly
            }
            //out here

            //ref can do everything out can do and more
            //should use out when you can because ref is
            //more of a performance issue

            object o = 3.4;

            //this is a down cast to double but with safe way to handle case where it is not double
            if(o is double num)
            {
                //in here num is the double if it is really a number

            }

            var num3 = o as string ?? "default";
            //will be "defult" if it was not really a string

            var num2 = (o as string);
            //will be null if it was not really a string

            //?? null conditional operator
            //a??b returns a if it's not null otherwise b
        }


        // swap
        //swap two variables values
        public static void Swap<T>(ref T value1, ref T value2)
        {
            T swap = value1;
            value1 = value2;
            value2 = swap;
        }
        
        
    }
}
