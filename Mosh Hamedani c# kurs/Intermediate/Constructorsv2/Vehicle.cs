using System;

namespace Constructorsv2
{
    public class Vehicle
    {
        private readonly string _registrationNumber;

//        public Vehicle()
//        {
//            Console.WriteLine("Vehicle is being Initialized.");
//        }

        public Vehicle(string registrationNumber)
        {
            _registrationNumber = registrationNumber;
            Console.WriteLine("Vehicle is being Initialized. {0}", registrationNumber);
        }
    }
}