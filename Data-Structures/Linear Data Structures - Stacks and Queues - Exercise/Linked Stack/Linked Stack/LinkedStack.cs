using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class LinkedStack<T>
 {
    private class Node<T>
    {
        public T Value;

        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
    }

    private Node<T> firstNode;

    public int Count { get; set; }

    public void Push (T element)
    {
        if (this.firstNode == null)
        {
            this.firstNode = new Node<T>(element);
        }
        else
        {
            this.firstNode = new Node<T>(element, this.firstNode);
        }
        this.Count++;
    }

    public T Pop ()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty!");
        }

        var element = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return element;
    }

    public T[] ToArray ()
    {
        T[] arr = new T[this.Count];

        var currentNode = this.firstNode;
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
