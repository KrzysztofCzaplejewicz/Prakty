using System;
using System.Collections;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Object array list, moze byc problem z pobraniem danych wartosci
            var list = new ArrayList();
            list.Add(1);
            list.Add("krisku");
            list.Add(DateTime.Today);

            var anotherList = new List<string>();
            // Wszystkie elementy sa stringami i nie trzeba boxowac
            anotherList.Add("chujek");
        }
    }
}
