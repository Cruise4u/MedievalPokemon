using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static ServiceLocator _instance;

    public static ServiceLocator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ServiceLocator>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("ServiceLocator");
                    _instance = go.AddComponent<ServiceLocator>();
                }
            }
            return _instance;
        }
    }

    private Dictionary<Type, HashSet<object>> services = new Dictionary<Type, HashSet<object>>();
    private Dictionary<(Type, int), object> indexedServices = new Dictionary<(Type, int), object>();

    public void RegisterService<T>(T service)
    {
        Type serviceType = typeof(T);
        if (!services.ContainsKey(serviceType))
        {
            services[serviceType] = new HashSet<object>();
        }
        services[serviceType].Add(service);
    }

    public void RegisterService<T>(T service, int index)
    {
        Type serviceType = typeof(T);
        indexedServices[(serviceType, index)] = service;
    }

    public IEnumerable<T> GetServices<T>()
    {
        Type serviceType = typeof(T);
        if (services.TryGetValue(serviceType, out HashSet<object> serviceSet))
        {
            return serviceSet.Cast<T>();
        }
        return Enumerable.Empty<T>();
    }

    public T GetService<T>(int index)
    {
        Type serviceType = typeof(T);
        if (indexedServices.TryGetValue((serviceType, index), out object service))
        {
            return (T)service;
        }
        return default;
    }
}
