using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public TextMeshProUGUI TurnManagerToast;
    private bool _hasCombatStarted;
 
    public int TurnCount;
    public int TurnID;
    public SquadManager squadOne;
    public SquadManager squadTwo;

    public List<SquadStats> SquadStatsList;

    public int GetSquadWaitingForTurn()
    {
        int value = -1;
        if(squadOne.IsTurnFinished() == false && squadTwo.IsTurnFinished() == true)
        {
            value = 0;
        }
        else if(squadOne.IsTurnFinished() == true && squadTwo.IsTurnFinished() == false)
        {
            value = 1;
        }
        return value;
    }

    public bool HasCombatStarted()
    {
        return _hasCombatStarted;
    }

    public bool HasSquadPlayedThisTurn(int squadID)
    {
        bool condition = false;
        if(squadID == 0)
        {
            condition = squadOne.IsTurnFinished();
        }
        else
        {
            condition = squadTwo.IsTurnFinished();
        }
        return condition;
    }
    public bool HasBothSquadsPlayedThisTurn()
    {
        if (squadOne.IsTurnFinished() == true && squadTwo.IsTurnFinished() == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetTurns()
    {
        TurnCount += 1;
        squadOne.ResetTurn();
        squadTwo.ResetTurn();
        Debug.Log("Reseting Turn Data..");
    }

    public void Init()
    {
        _hasCombatStarted = true;
        TurnID = -1;
        TurnCount = -1;
        AssignSquadStats();
        InitializeSquads();
    }

    public void InitializeSquads()
    {
        squadOne.Init();
        squadTwo.Init();
    }

    public void AssignSquadStats()
    {
        SquadStatsList = new List<SquadStats>();
        SquadStatsList.Add(squadOne.SquadStats);
        SquadStatsList.Add(squadTwo.SquadStats);
        foreach(SquadStats stats in SquadStatsList)
        {
            stats.Init();
        }
    }

    public void CheckSquadSpeed()
    {
        Debug.Log("Checking Squad Speed");
        Debug.Log("Turn n: "+ TurnCount);
        if (SquadStatsList[0].SquadSpeed > SquadStatsList[1].SquadSpeed)
        {
            TurnID = 0;
        }
        else
        {
            TurnID = 1;
        }
        DisplayTurn();
    }



    public bool IsSquadSpeedHighest(int squadListArrayElement)
    {
        if(squadListArrayElement == 0)
        {
            if (SquadStatsList[0].SquadSpeed >= SquadStatsList[1].SquadSpeed)
            {
                TurnID = 0;
            }
        }
        else
        {
            if (SquadStatsList[0].SquadSpeed < SquadStatsList[1].SquadSpeed)
            {
                TurnID = 1;
            }
        }
        return true;
    }

    public void DisplayTurn()
    {
        GUIDisplayHelper.DisplayTurn(TurnManagerToast, TurnID);
        Debug.Log("Turn ID is : ..." + TurnID);
    }
}

public static class GUIDisplayHelper
{
    public static void DisplayTurn(TextMeshProUGUI text,int turnID)
    {
        if(turnID == 0)
        {
            text.text = "Player Turn";
        }
        else
        {
            text.text = "AI Turn";
        }

    }
}


//public class GameManager : MonoBehaviour
//{
//    public List<SquadStats> SquadStatsList;
//    public int turnID;
//    private IGameState _currentState;


//    void Start()
//    {
//        SetState(new PlayerTurnState());
//    }

//    void Update()
//    {
//        _currentState.UpdateState(this);
//    }

//    public void SetState(IGameState newState)
//    {
//        _currentState = newState;
//        _currentState.EnterState(this);
//    }

//}


//public class PlayerTurnState : IGameState
//{
//    public void EnterState(GameManager gameManager)
//    {
//        Debug.Log("Player's Turn");
//    }

//    public void UpdateState(GameManager gameManager)
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            // Execute player action
//            Debug.Log("Player attacks!");
//            gameManager.SetState(new AITurnState());
//        }
//    }
//}

//public class AITurnState : IGameState
//{
//    public void EnterState(GameManager gameManager)
//    {
//        Debug.Log("AI's Turn");
//        // Execute AI action
//        Debug.Log("AI attacks!");
//        gameManager.SetState(new PlayerTurnState());
//    }

//    public void UpdateState(GameManager gameManager)
//    {
//        // AI logic can be processed here if needed
//    }
//}

//public interface IGameState
//{
//    void EnterState(GameManager gameManager);
//    void UpdateState(GameManager gameManager);
//}
