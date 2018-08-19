using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    class Item
    {
        public int Value { get; private set; }

        public Item PrevItem { get; private set; }

        public Item (int value, Item prevItem)
        {
            this.Value = value;
            this.PrevItem = prevItem;
        }
    }

    static void Main(string[] args)
    {
        int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int n = line[0];
        int m = line[1];

        List<int> result = new List<int>();

        Queue<Item> queue = new Queue<Item>();

        queue.Enqueue(new Item(n, null));

        while (queue.Count > 0)
        {
            Item current = queue.Dequeue();
            if (current.Value < m)
            {
                queue.Enqueue(new Item(current.Value + 1, current));
                queue.Enqueue(new Item(current.Value + 2, current));
                queue.Enqueue(new Item(current.Value * 2, current));
            }

            if (current.Value == m)
            {
                while (current != null)
                {
                    result.Add(current.Value);
                    current = current.PrevItem;
                }
                result.Reverse();

                Console.WriteLine(string.Join(" -> ", result));
                return;
            }
        } 
    }
}
