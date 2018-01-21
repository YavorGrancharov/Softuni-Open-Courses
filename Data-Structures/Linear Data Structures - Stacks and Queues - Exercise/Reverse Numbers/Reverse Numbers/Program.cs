using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();


            Stack<int> output = new Stack<int>();

            for (int i = 0; i < input.Count; i++)
            {
                output.Push(input[i]);
            }

            foreach (var entry in output)
            {
                Console.Write(entry + " ");
            }
            Console.WriteLine();
        }
    }
}
