using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var count = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!count.ContainsKey(num))
                {
                    count.Add(num, 0);
                }
                count[num]++;
            }
            foreach (var num in count.OrderBy(x => x.Key))
            {
                Console.WriteLine("{0} -> {1} times", num.Key, num.Value);
            }
        }
    }
}
