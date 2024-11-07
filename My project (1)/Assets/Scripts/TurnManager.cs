using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public TextMeshProUGUI TurnManagerToast;

    public int TurnID;
    public SquadStats squadOne;
    public SquadStats squadTwo;

    public List<SquadStats> SquadStatsList;

    public void AssignSquadStats()
    {
        SquadStatsList = new List<SquadStats>();
        SquadStatsList.Add(squadOne);
        SquadStatsList.Add(squadTwo);
        SquadStats[] squadStatsArray = FindObjectsOfType<SquadStats>();
        foreach (SquadStats stats in squadStatsArray)
        {
            if (stats.squadID == 0)
            {
                SquadStatsList.Add(stats);
            }
            else
            {
                SquadStatsList.Add(stats);
            }
        }
    }


    public void Init()
    {
        TurnID = -1;
        AssignSquadStats();
    }

    public void CheckSquadSpeed()
    {
        Debug.Log("Squad One Speed is :" + SquadStatsList[0].SquadSpeed);
        Debug.Log("Squad Two Speed is :" + SquadStatsList[1].SquadSpeed);


        if (SquadStatsList[0].SquadSpeed > SquadStatsList[1].SquadSpeed)
        {
            TurnID = 0;
        }
        else
        {
            TurnID = 1;
        }
        GUIManager.DisplayTurn(TurnManagerToast, TurnID);
    }

}

public static class GUIManager
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
