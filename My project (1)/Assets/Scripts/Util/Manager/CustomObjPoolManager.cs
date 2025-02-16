using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CustomObjPoolManager : ManagerBase
{
    private Dictionary<System.Type, object> pools = new Dictionary<System.Type, object>();

    public override IEnumerator Init()
    {
        // Initialize the ObjectPoolManager

        yield return null;
    }

    public void CreatePool<T>(int size) where T : new()
    {
        var pool = new CustomObjPool<T>(size);
        pools[typeof(T)] = pool;
    }

    public CustomObjPool<T> GetPool<T>() where T : new()
    {
        return pools[typeof(T)] as CustomObjPool<T>;
    }
}
