using UnityEngine;

public class SquadManager : MonoBehaviour
{
    private bool _isTurnEnd;
    public SquadStats SquadStats;

    public void ResetTurn()
    {
        _isTurnEnd = false;
        Debug.Log("My current turn data is .." + _isTurnEnd);
    }

    public void Init()
    {
        _isTurnEnd = false;
    }

    public void FinishTurn()
    {
        _isTurnEnd = true;
        Debug.Log("Finished My Turn! I'm Squad " + gameObject.name);
    }

    public bool IsTurnFinished()
    {
        return _isTurnEnd;
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
