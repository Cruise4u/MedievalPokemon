using System.Collections.Generic;
using UnityEngine;

public class CustomObjPool<T> where T : new()
{
    private readonly Queue<T> pool;
    private readonly int poolSize;

    public CustomObjPool(int size)
    {
        poolSize = size;
        pool = new Queue<T>();

        for (int i = 0; i < poolSize; i++)
        {
            pool.Enqueue(new T());
        }
    }

    public T Get()
    {
        if (pool.Count > 0)
        {
            return pool.Dequeue();
        }
        else
        {
            // Optionally, create a new instance if the pool is empty
            return new T();
        }
    }

    public void Return(T item)
    {
        pool.Enqueue(item);
    }

}