namespace System;

public class MyList<T>
{
    private int size;
    private List<T> elements = new List<T>();
    
    public MyList()
    {
        size = 0;
        elements = new List<T>();
    }

    void Add(T element)
    {
        elements[size++] = element;
    }

    T Remove(int index)
    {
        if (index >= size)
        {
            throw new ArgumentOutOfRangeException();
        }

        T removed = elements[index];
        List<T> copied = new List<T>();
        int count = 0;
        for (int i = 0; i < elements.Count; i++)
        {
            if (i == index)
            {
                count--;
            }
            else
            {
                copied[count] = elements[i];
            }
            count++;
        }

        elements = copied.ToList();
        size--;
        return removed;
    }

    bool Contains(T element)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    void Clear()
    {
        size = 0;
        elements = new List<T>();
    }

    void InsertAt(T element, int index)
    {
        List<T> copied = new List<T>();
        int count = 0;
        for (int i = 0; i < elements.Count; i++)
        {
            if (i == index)
            {
                copied[count] = element;
                i--;
            }
            else
            {
                copied[count] = elements[i];
            }
            count++;
        }

        elements = copied.ToList();
        size++;
    }

    void DeleteAt(int index)
    {
        Remove(index);
    }

    T Find(int index)
    {
        return elements[index];
    }
}