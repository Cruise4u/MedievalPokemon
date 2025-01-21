using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ManagerInitializer : SerializedMonoBehaviour
{
    [SerializeField]
    Queue<ManagerBase> managerQueue = new Queue<ManagerBase>();

    public void BaseInit()
    {
        ManagerBase[] managers = FindObjectsOfType<ManagerBase>();
        foreach (var manager in managers)
        {
            ServiceLocator.RegisterService(manager);
        }

        managerQueue.Enqueue(ServiceLocator.GetService<SquadManager>(0));
        managerQueue.Enqueue(ServiceLocator.GetService<SquadManager>(1));
        managerQueue.Enqueue(ServiceLocator.GetService<TargetManager>(0));
        managerQueue.Enqueue(ServiceLocator.GetService<TargetManager>(1));
        managerQueue.Enqueue(ServiceLocator.GetService<InputManager>());
        managerQueue.Enqueue(ServiceLocator.GetService<TurnManager>());

        int initialQueueSize = managerQueue.Count; // Store the initial queue size

        for (int i = 0; i < initialQueueSize; i++)
        {
            var manager = managerQueue.Dequeue();
            Debug.Log("Queue Element is : " + manager);
            StartCoroutine(manager.Init());
        }
    }


}
