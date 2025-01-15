using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

public class ManagerRegistry : SerializedMonoBehaviour
{
    private Dictionary<System.Type, List<IManager>> managers = new Dictionary<System.Type, List<IManager>>();

    private void Awake()
    {
        RegisterManagers();
    }

    private void RegisterManagers()
    {
        // Find and register all managers in the scene
        IManager[] foundManagers = FindObjectsOfType<MonoBehaviour>().OfType<IManager>().ToArray();
        foreach (IManager manager in foundManagers)
        {
            Type managerType = manager.GetType();
            if (!managers.ContainsKey(managerType))
            {
                managers[managerType] = new List<IManager>();
            }
            managers[managerType].Add(manager);
        }
    }

    public List<T> GetManagers<T>() where T : class, IManager
    {
        managers.TryGetValue(typeof(T), out List<IManager> managerList);
        return managerList?.Cast<T>().ToList();
    }

    //public List<T> GetManagers<T>(int index) where T : class, IManager
    //{
    //    managers.Where(manager => manager.ValueTryGetValue(typeof(T), out List<IManager> managerList);
    //    return managerList?.Cast<T>().ToList();
    //}

    public void InitializeManager()
    {

    }

}
