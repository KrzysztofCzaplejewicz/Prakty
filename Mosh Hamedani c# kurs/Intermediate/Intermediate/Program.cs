using System;
using System.Threading;

namespace Intermediate
{
    public class Person
    {
        public string Name;

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I'm {1}", to, Name);
        }
        public static Person Parse(string str)
        {
            var person = new Person();
            person.Name = str;

            return person;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.Parse("Krisku");
            person.Introduce("CHUJU");
            Thread.Sleep(2000);
        }
    }
}
