using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("Sum={0}; Average={1:F2}", sum, numbers.Average());
        }
    }
}
