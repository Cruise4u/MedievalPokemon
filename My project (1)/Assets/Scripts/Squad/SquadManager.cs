using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadManager : MonoBehaviour, ICombatManager
{
    private SquadStats _squadStats;
    public SquadStats SquadStats { get { return _squadStats; } }

    public IEnumerator Init()
    {
        _squadStats.Init();
        yield return null;
    }

    public void StartCombatInit()
    {
        StartCoroutine(Init());
    }

}
