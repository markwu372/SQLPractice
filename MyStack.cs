namespace System;

public class MyStack<T>
{
    private int size;
    private List<T> elements;

    public MyStack()
    {
        size = 0;
        elements = new List<T>();
    }

    public int Count()
    {
        return size;
    }

    public T Pop()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        T last = elements[size - 1];
        elements.RemoveAt(size-1);
        size--;
        return last;
    }

    public void Push(T elem)
    {
        elements.Add(elem);
        size++;
    }
}