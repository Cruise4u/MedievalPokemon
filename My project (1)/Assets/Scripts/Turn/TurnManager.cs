using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TurnManager : ManagerBase
{
    public GameObject playerSquadGO;
    public GameObject cpuSquadGO;

    public TextMeshProUGUI TurnManagerToast;
    public TextMeshProUGUI CombatResultToast;

    private Dictionary<ECombatState, bool> _combatStateDictionary;
    private Dictionary<ESquad, bool> _squadTurnDictionary;


    private int _turnCount;
    public int TurnCount { get => _turnCount; set => _turnCount = value; }

    private int[] _speedArray;
    public int[] SpeedArray { get => _speedArray; set => _speedArray = value; }

    public override IEnumerator Init()
    {
        var squadStats = FindObjectsOfType<SquadStats>();
        _speedArray = new int[2];
        _speedArray = squadStats
            .OrderBy(squad => squad.SquadID)
            .Select(squad => squad.SquadSpeed)
            .ToArray();

        Debug.Log("Speed value for array 0 " + _speedArray[0]);
        Debug.Log("Speed value for array 1 " + _speedArray[1]);


        _squadTurnDictionary = new Dictionary<ESquad, bool>
        {
            { ESquad.Player, true },
            { ESquad.CPU, true }
        };
        _turnCount = -1;
        yield return null;
    }

    public void StartSystemInit()
    {
        StartCoroutine(Init());
    }

    public void SetSquadsTurnCondition(bool isPlayerTurn, bool isCPUTurn)
    {
        _squadTurnDictionary[ESquad.Player] = isPlayerTurn;
        _squadTurnDictionary[ESquad.CPU] = isCPUTurn;
    }

    public void SetSquadTurn(ESquad squadName, bool isTurn)
    {
        _squadTurnDictionary[squadName] = isTurn;
    }

    public bool hasCombatStarted()
    {
        if (_squadTurnDictionary[ESquad.Player] && _squadTurnDictionary[ESquad.CPU])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsSquadTurnActive(ESquad squadName)
    {
        return _squadTurnDictionary[squadName];
    }

    public bool IsPlayersTurn()
    {
        if (_speedArray[0] >= _speedArray[1])
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


}
