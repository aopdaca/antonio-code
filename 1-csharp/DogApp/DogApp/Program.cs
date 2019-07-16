using System;

namespace DogApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog("Scooby Doo");
            dog.Owner = "Shaggy";
            dog.Bark();
            Console.WriteLine(dog.Identifier);
        }
    }
}
