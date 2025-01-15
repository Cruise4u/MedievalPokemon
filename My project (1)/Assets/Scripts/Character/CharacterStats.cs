using System.Collections;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    public int MaxAttackPower { get => _maxAttackPower; set => _maxAttackPower = value; }
    public int CurrentAttackPower { get => _currentAttackPower; set => _currentAttackPower = value; }

    public int MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; } 
    public int CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }

    [SerializeField]
    private int _maxHealth;
    private int _currentHealth;

    [SerializeField]
    private int _maxAttackPower;
    private int _currentAttackPower;

    [SerializeField]
    private int _maxSpeed;
    private int _currentSpeed;

    public void SetStats()
    {
        _currentHealth = _maxHealth;
        _currentAttackPower = _maxAttackPower;
        _currentSpeed = _maxSpeed;
    }

    public void Init()
    {
        SetStats();
    }

    public void ShowHealthStats()
    {
        Debug.Log("Max HP is : " + MaxHealth);
        Debug.Log("Current HP is : " + CurrentHealth);
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
