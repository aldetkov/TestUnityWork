using CardTask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool<T> : ObjectPool<T> where T : BasePoolObject
{
    private readonly Transform _container;

    public CardPool(IPoolFactory<T> factory, Transform container) : base(factory)
    {
        _container = container;
    }
    public override T GetObject()
    {
        var obj = base.GetObject();

        obj.gameObject.SetActive(true);

        return obj;
    }

    public override void ReturnObject(T obj)
    {
        obj.transform.SetParent(_container);
        obj.gameObject.SetActive(false);
        base.ReturnObject(obj);
    }
}

