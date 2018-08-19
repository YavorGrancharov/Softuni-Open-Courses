using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    private BinarySearchTree (Node node)
    {
        this.root = node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int lowerRange = startRange.CompareTo(node.Value);
        int higherRange = endRange.CompareTo(node.Value);

        if (lowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (lowerRange <= 0 && higherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (higherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
        }

        Node parent = null;

        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(value);
            //if current.Value . value
            if (compare > 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (compare < 0)
            {
                //if current.Value < value
                parent = current;
                current = current.Right;
            }
            else
            {
                return;
            }
        }

        Node newNode = new Node(value);
        if (parent.Value.CompareTo(value) > 0)
        {
            //parent.Value > value
            parent.Left = newNode;
        }
        else
        {
            //parent.Value < value
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(value);
            if (compare > 0)
            {
                //current.Value > value
                current = current.Left;
            }
            else if (compare < 0)
            {
                //current.Value < value
                current = current.Right;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node parent = null;
        Node min = this.root;
         while (min.Left != null)
        {
            parent = min;
            min = parent.Right;
        }

        if (parent == null)
        {
            this.root = min.Right;
        }
        else
        {
            parent.Left = min.Right;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(item);

            if (compare > 0)
            {
                //current.Value > item
                current = current.Left;
            }
            else if (compare < 0)
            {
                //current,Value < item
                current = current.Right;
            }
            else
            {
                //current.Value == item
                return new BinarySearchTree<T>(current);
            }
        }
        return null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder (Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private class Node 
    {
        public Node (T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> BST = new BinarySearchTree<int>();

        BST.Insert(20);
        BST.Insert(16);
        BST.Insert(28);
        BST.Insert(14);
        BST.Insert(29);
        BST.Insert(29);

        List<int> list = new List<int>();

        BST.EachInOrder(list.Add);

        Console.WriteLine(string.Join(" ",list));
    }
}
