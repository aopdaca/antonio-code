using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    class MoviePlayer
    {
        public Movie Currentmovie { get; set; }

        //we have events in C# that can be subscribed to
        //one object can fire an event without having to know about all the subscribers who want to react to it

        //before i define the event, i need to define a delegate type to represent
        //the methods that can subbscribe to the event

        //this line defines a tyoe not a field of this class
        //this type means a function with zero param and void returns
        public delegate void MovieEndHandlerNoParam();


        public delegate void MovieEndHandlerWithTitle(string Title);

        //defines an event, and methods "shaped like" MovieEndHandlerNoParam

        //public event MovieEndHandlerNoParam MovieEnd;

        //public event MovieEndHandlerWithTitle MovieEnd;

        //with generics, we have func and action types
        public event MovieEndHandlerWithTitle MovieEnd;


        public void Play()
        {
            Console.WriteLine("PlayingMovie");
            Thread.Sleep(3000);

            //you fire an event simply by calling it like a method

            //if(MovieEnd != null)
            //{
            //    MovieEnd();
            //}

            MovieEnd?.Invoke(Currentmovie.Title);

            //that will run all methods that are subscribed to the event
            
            //events with no subcribers are null, and cause null exception when fired
            //so we need to check against null first

            //in c#, we have a couple of null handling operators
            //?, is the null-conditional operator
            //it means, behave like . if the thing to the left is not null
            //otherwise do nothing at all
            //otherwise do nothing at all
        }
    }
}
