using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static GameCore INSTANCE;

    [SerializeField] StateMashine stateMashine;
    public StateMashine StateMashine { get => stateMashine; set => stateMashine = value; }
    

    [SerializeField] List<GameEvent> gameEvents;
    [SerializeField] GameEvent currentGameEvent;

    [SerializeField] int baseResValue = 25;
    public int BaseResValue { get => baseResValue; set => baseResValue = value; }

    private void Awake()
    {
        INSTANCE = this;
        StateMashine.GameStateChangeEvent += GameStateChange;       
    }

    private void Start()
    {
        stateMashine = Instantiate(stateMashine, transform);
        ShowNewEvent();
    }
    private void OnDestroy()
    {
        StateMashine.GameStateChangeEvent -= GameStateChange;        
    }
    
    private void GameStateChange(StateMashine s)
    {
        ShowNewEvent();
    }

    private void ShowNewEvent()
    {
        if (stateMashine.CurrentGameState == GameState.StartTurn)
        {
            DelCurrentEvent();

            List<GameEvent> notCompletedEvents = SelectNotCompletedEvents();
            if(notCompletedEvents.Count == 0)
            {
                GameEnd();
            }
            else
            {
                currentGameEvent = Instantiate(notCompletedEvents[Random.Range(0, notCompletedEvents.Count)]);
            }
            
        }
    }
    private List<GameEvent> SelectNotCompletedEvents()
    {
        List<GameEvent> notCompletedEvents = new List<GameEvent>();
        foreach (GameEvent ge in gameEvents)
        {            
            if (ge.GameEventData.Completed == Completed.No)
            {
                notCompletedEvents.Add(ge);
            }
        }
        return notCompletedEvents;
    }
    private void DelCurrentEvent()
    {
        if(currentGameEvent != null)
        {
            Destroy(currentGameEvent.gameObject);
        }
    }
    private void GameEnd()
    {
        Debug.Log("GameEnds");
    }
}
