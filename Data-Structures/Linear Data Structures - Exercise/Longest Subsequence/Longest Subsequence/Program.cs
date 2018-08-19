using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int maxNumber = 0;
            int maxCount = 0;
            for (int i = 0; i < input.Count; i++)
            {
                int currentCount = 1;
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[i] == input[j])
                    {
                        currentCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentCount > maxCount)
                {
                    maxNumber = input[i];
                    maxCount = currentCount;
                }
            }
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumber + " ");
            }
            Console.WriteLine();
        }
    }
}
