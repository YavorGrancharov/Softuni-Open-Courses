using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedQueue<T>
{
    private class QueueNode<T>
    {
        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode (T value)
        {
            this.Value = value;
        }
    }

    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; set; }

    public void Enqueue (T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            var oldTail = this.tail;
            this.tail = new QueueNode<T>(element);
            this.tail.PrevNode = oldTail;
            oldTail.NextNode = this.tail;
        }
        this.Count++;
    }

    public T Dequeue ()
    {
        T element;
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else if (this.Count == 1)
        {
            element = this.head.Value;
            this.head = this.tail = null;
        }
        else
        {
            element = this.head.Value;
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }

        this.Count--;
        return element;
    }

    public T[] ToArray ()
    {
        T[] arr = new T[this.Count];

        var currentNode = this.head;
        int index = 0;

        while (currentNode != null)
        {
            arr[index] = currentNode.Value;
            index++;
            currentNode = currentNode.NextNode;
        }
        return arr;
    }
}
