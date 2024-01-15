using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : IPool<T> where T : IPoolObject
{
    private readonly IPoolFactory<T> _factory;
    private readonly Queue<T> _queue;

    protected ObjectPool(IPoolFactory<T> factory)
    {
        _factory = factory;
        _queue = new Queue<T>();
    }
    public virtual T GetObject()
    {
        return _queue.Count > 0 ? _queue.Dequeue() : CreateObject();
    }

    public virtual void ReturnObject(T obj)
    {
        _queue.Enqueue(obj);
    }

    protected virtual T CreateObject()
    {
        var poolObject = _factory.CreateObject();
        poolObject.Initialize(this as IPool<IPoolObject>);
        return poolObject;
    }
}

public abstract class BasePoolObject : MonoBehaviour, IPoolObject
{
    protected IPool<IPoolObject> _pool;
    public virtual void Initialize(IPool<IPoolObject> pool)
    {
        _pool = pool;
    }

    public virtual void Return()
    {
        _pool.ReturnObject(this);
    }
}

public interface IPoolObject
{
    void Initialize(IPool<IPoolObject> pool);
    void Return();
}

public interface IPool<T>
{
    T GetObject();
    void ReturnObject(T obj);
}