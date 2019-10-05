using UnityEngine;
using System.Collections;

public enum GameState
{
    StartTurn,
    Event,
    EndTurn
    
}

public class StateMashine : MonoBehaviour
{
    GameState currentGameState;
    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
        }
        set
        {
            currentGameState = value;
            if(GameStateChangeEvent != null)
            {
                GameStateChangeEvent(this);
            }
        }
    }
    

    public delegate void GameStateChangeDel(StateMashine s);
    public static event GameStateChangeDel GameStateChangeEvent;

    private void Awake()
    {
        Stamp.PushOnStampEvent += PushOnStamp;        
    }

    private void Start()
    {
        currentGameState = GameState.StartTurn;
    }
    private void OnDestroy()
    {
        Stamp.PushOnStampEvent -= PushOnStamp;
    }
    private void PushOnStamp(Stamp s)
    {
        currentGameState = GameState.EndTurn;
    }
}
