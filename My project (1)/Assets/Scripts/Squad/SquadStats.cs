using System.Collections.Generic;
using UnityEngine;

public class SquadStats : MonoBehaviour
{

    public List<CharacterStats> characterStatList;

    public int SquadSpeed { get => _squadSpeed; set => _squadSpeed = value;}

    private int _squadSpeed;

    private int _squadID;

    public int SquadID { get => _squadID; set => _squadID = value; }


    public void Init()
    {
        SetSquadSpeed();
    }

    public void SetSquadSpeed()
    {
        foreach(CharacterStats character in characterStatList)
        {
            character.Init();
            _squadSpeed = 0;
            _squadSpeed += character.CurrentSpeed;
        }
    }

    public void DisplaySquadSpeed()
    {
        Debug.Log("Squad speed is:" + SquadSpeed);
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
