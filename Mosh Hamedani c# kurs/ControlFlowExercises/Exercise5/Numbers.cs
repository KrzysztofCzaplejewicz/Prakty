using System;
using System.Collections.Generic;

namespace Exercise5
{
    class Numbers
    {
        public static List<int> GetNumbers(List<int> numbers, string[] elements)
        {
            foreach (var number in elements)
            {
                numbers.Add(Convert.ToInt32(number));
            }
            return numbers;
        }
    }
}