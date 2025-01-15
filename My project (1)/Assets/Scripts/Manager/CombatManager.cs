using System.Collections;
using UnityEngine;



public class CombatManager : MonoBehaviour, IManager
{
    //public void CombatInit()
    //{
    //    StartCoroutine(InitializeManagers());
    //}

    public IEnumerator Init()
    {
        yield return null; // Simulate some initialization delay if needed
    }

    //private IEnumerator InitializeManagers()
    //{
    //    // Initialize main managers first
    //    yield return StartCoroutine(InitializeBatch(managers));

    //    // Initialize squads next
    //    yield return StartCoroutine(InitializeBatch(squads));

    //    // Initialize units last
    //    yield return StartCoroutine(InitializeBatch(units));

    //    Debug.Log("All initialization complete.");
    //}

    //private IEnumerator InitializeBatch(IManager[] batch)
    //{
    //    List<Coroutine> initCoroutines = new List<Coroutine>();

    //    for (int i = 0; i < batch.Length; i++)
    //    {
    //        if ((object)batch[i] != this)
    //        {
    //            Coroutine initCoroutine = StartCoroutine(batch[i].Init());
    //            initCoroutines.Add(initCoroutine);
    //            Debug.Log($"{batch[i].GetType().Name} initialization started.");
    //        }
    //    }

    //    // Wait for all initializations in this batch to complete
    //    foreach (var coroutine in initCoroutines)
    //    {
    //        yield return coroutine;
    //    }

    //    Debug.Log("Batch initialization complete.");
    //}
}
