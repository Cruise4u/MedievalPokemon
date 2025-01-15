using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix;
using System.Linq;

public enum ESquad
{
    Player,
    CPU,
}

public enum ECombatState
{
    Started,
    Finished,
}

public class TurnManager : MonoBehaviour, ISystemManager
{
    public TextMeshProUGUI TurnManagerToast;
    public TextMeshProUGUI CombatResultToast;

    private Dictionary<ECombatState, bool> _combatStateDictionary;
    private Dictionary<ESquad, bool> _squadTurnDictionary;

    private int _turnCount;
    public int TurnCount { get => _turnCount; set => _turnCount = value; }

    private int[] _speedArray;
    public int[] SpeedArray { get => _speedArray; set => _speedArray = value; }

    public void SetSquadsTurnCondition(bool condition1,bool condition2)
    {
        _squadTurnDictionary[ESquad.Player] = condition1;
        _squadTurnDictionary[ESquad.CPU] = condition2;
    }

    public bool GetSquadTurnCondition(ESquad squadName)
    {
        return _squadTurnDictionary[squadName];
    }

    public bool IsPlayerFirstOnTurn()
    {
        if (SpeedArray[0] >= SpeedArray[1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetCombatStateCondition(ECombatState state)
    {
        return _combatStateDictionary[state];
    }
    public bool HasSquadFinishedTurn(ESquad squad)
    {
        return _squadTurnDictionary[squad];
    }
    public IEnumerator Init()
    {
        var squadManagers = FindObjectsOfType<SquadManager>();
        _speedArray = squadManagers.Select(squad => squad.SquadStats.SquadSpeed).ToArray();

        _turnCount = -1;

        yield return null;
    }
    public void StartSystemInit()
    {
        StartCoroutine(Init());
    }
    //public void CheckSquadSpeed()
    //{
    //    Debug.Log("Checking Squad Speed");
    //    Debug.Log("Turn n: " + TurnCount);
    //    if (SquadStatsList[0].SquadSpeed > SquadStatsList[1].SquadSpeed)
    //    {
    //        SetTurnID(0);
    //    }
    //    else
    //    {
    //        SetTurnID(1);
    //    }
    //    DisplayTurn();
    //}
}
