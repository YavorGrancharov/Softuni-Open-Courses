using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Sequence
{
    class Program
    {
        static void Sequence (int n)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            List<int> result = new List<int>();

            while (result.Count < 50)
            {
                int current = queue.Dequeue();
                result.Add(current);
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
            Console.WriteLine(string.Join(", ",result));
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Sequence(n);
        }
    }
}
