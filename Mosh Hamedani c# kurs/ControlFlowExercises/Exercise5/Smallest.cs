using System.Collections.Generic;

namespace Exercise5
{
    class Smallest
    {
        public static List<int> GetSmallest(List<int> smallest, List<int> numbers)
        {
            while (smallest.Count < 3)
            {
                var min = numbers[0];
                foreach (var number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }

                }
                smallest.Add(min);
                numbers.Remove(min);

            }
            return smallest;
        }
    }
}