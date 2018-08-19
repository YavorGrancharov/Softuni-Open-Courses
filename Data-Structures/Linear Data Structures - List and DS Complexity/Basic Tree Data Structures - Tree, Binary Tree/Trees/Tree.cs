using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; private set; }

    public IList<Tree<T>> Children { get; private set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();

        foreach (Tree<T> child in children)
        {
            this.Children.Add(child);
        }
    }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);

        foreach (Tree<T> child in this.Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (Tree<T> child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();

        this.DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> node, List<T> result)
    {
        foreach (Tree<T> child in node.Children)
        {
            this.DFS(child, result);
        }

        result.Add(node.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        List<T> result = new List<T>();
        Queue<Tree<T>> queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Tree<T> current = queue.Dequeue();
            result.Add(current.Value);
            foreach (Tree<T> child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
        return result;
    }
}
