using System;

public class Tree<T>
{
    public T Value { get; set; }
    public IList<Tree<T>> Children { get; set; }

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
        Console.Write(new string(" ", indent * 2));
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
}
