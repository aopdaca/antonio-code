using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

        // For each number from 1 to 1000 in order,
        // * print "Fizz" for the ones divisible by 3 (& not 5)
        // * print "Buzz" for the ones divisible by 5 (& not 3)
        // * print "Fizzbuzz" for the ones divisible by both 3 and 5
        // * print the number itself, for all the rest of the numbers
        // Also, I want to know, at the end, how many Fizz, how many Buzz, how many Fizzbuzz.

            int fizz = 0;
            int buzz = 0;
            int fizzbuzz = 0;


            for(int i = 1; i <1001;i++){
                if(i%3==0&&i%5!=0){
                    Console.WriteLine("Fizz");
                    fizz = fizz + 1;
                } else if(i%3!=0&&i%5==0){
                    Console.WriteLine("Buzz");
                    buzz = buzz +1;
                } else if(i%3==0&&i%5==0){
                    Console.WriteLine("FizzBuzz");
                    fizzbuzz = fizzbuzz + 1;
                } else {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine(fizz);
            Console.WriteLine(buzz);
            Console.WriteLine(fizzbuzz);
        }
    }
}
