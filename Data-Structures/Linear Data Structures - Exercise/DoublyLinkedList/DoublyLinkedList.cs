using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class Node<T>
    {
        public T Value { get; private set; }

        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    private Node<T> head;
    private Node<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new Node<T>(element);
        }
        else
        {
            Node<T> newHead = new Node<T>(element);
            newHead.Next = this.head;
            this.head.Prev = newHead;
            this.head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new Node<T>(element);
        }
        else
        {
            Node<T> newTail = new Node<T>(element);
            newTail.Prev = this.tail;
            this.tail.Next = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty List");
        }

        T first = this.head.Value;
        this.head = this.head.Next;
        if (this.head != null)
        {
            this.head.Prev = null;
        }
        else
        {
            this.tail = null;
        }

        this.Count--;
        return first;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty List");
        }

        T last = this.tail.Value;
        this.tail = this.tail.Prev;
        if (this.tail != null)
        {
            this.tail.Next = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;
        return last;
    }

    public void ForEach(Action<T> action)
    {
        var current = this.head;
        while (current != null)
        {
            action(current.Value);
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this.head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];

        Node<T> current = this.head;

        int index = 0;
        while (current != null)
        {
            arr[index++] = current.Value;
            current = current.Next;
        }
        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
