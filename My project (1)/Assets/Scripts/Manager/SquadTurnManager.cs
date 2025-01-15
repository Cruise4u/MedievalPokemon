using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SquadTurnManager : MonoBehaviour, ICombatManager
{
    public TurnManager TurnManager;
    public SquadStats SquadStats;

    public int TurnID { get => _turnID; set => _turnID = value; }
    public bool HasCombatFinished { get => _hasCombatFinished;  }


    [SerializeField]
    private int _turnID;
    private bool _isTurnEnd;
    private bool _hasCombatFinished;

    public void StartCombatInit()
    {
        StartCoroutine(Init());
    }

    public IEnumerator Init()
    {
        _hasCombatFinished = false;
        _isTurnEnd = false;
        SetTurn(_turnID);
        yield return null;
    }

    public void SetTurn(int turnID)
    {
        TurnID = turnID;
    }

    public void FinishTurn()
    {
        _isTurnEnd = true;
        Debug.Log("Finished My Turn! I'm Squad " + gameObject.name);
    }

    public void ResetTurn()
    {
        _isTurnEnd = false;
        Debug.Log("My current turn data is .." + _isTurnEnd);
    }

    public bool IsTurnFinished()
    {
        return _isTurnEnd;
    }


}
