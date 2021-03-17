using System;

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
            Greetings.Run();

            Console.In.ReadLine();
        }
    }
}
