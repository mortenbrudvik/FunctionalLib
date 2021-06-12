using System;
using System.Collections.Generic;
using Fun;
using static Fun.Prelude;

namespace FunctionalConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var car = Some(new Car("Jaguar"));
            var car2 = None;

            var cars = new List<Option<Car>> {Some(new Car("Volvo")), None,Some(new Car("Fiat"))};
            
            // Test bind a function that return an option
            

            

            Console.In.ReadLine();
        }
        
        public class Car
        {
            public Car(string brand)
            {
                Brand = brand;
            }
            public string Brand { get; set; }
        }
    }
}
