using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface PoolInterface<T>
{
    //void SetManagedPool(T pool, Transform parent = null);
    void DestroyPool();
    void SetManagedPool(IObjectPool<GameObject> pool, Transform parent = null);
    void Init();
}
