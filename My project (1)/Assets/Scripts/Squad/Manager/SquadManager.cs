using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadManager : ManagerBase
{
    private SquadStats _squadStats;
    public SquadStats SquadStats { get { return _squadStats; } }

    public override IEnumerator Init()
    {
        Debug.Log("Squad Init!");
        _squadStats = GetComponent<SquadStats>();
        _squadStats.Init();
        yield return null;
    }

    public void StartCombatInit()
    {
        StartCoroutine(Init());
    }

}

