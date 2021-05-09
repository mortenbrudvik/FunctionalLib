using System;

using Fun;
using static Fun.Predlude;

namespace FunctionalConsole
{
    public class Program
    {
        /// <summary>
        /// This code is based on the book Functional C# book by Manning.
        /// https://www.manning.com/books/functional-programming-in-c-sharp
        /// Code examples from the book can be found on:
        /// https://github.com/la-yumba/functional-csharp-code
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var car = Some(new Car());
            var car2 = None;

            

            Console.In.ReadLine();
        }
        
        public class Car
        {
            public string Brand { get; set; }
        }
    }
}
