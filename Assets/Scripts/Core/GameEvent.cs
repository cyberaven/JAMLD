using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Completed
{
    Yes,
    No
}
public enum Decision
{
    Green,
    Red
}

public class GameEvent : MonoBehaviour
{
    [SerializeField] GameEventData gameEventData;

    public GameEventData GameEventData { get => gameEventData; set => gameEventData = value; }

    public delegate void NewGameEventDel(GameEvent gameEvent);
    public static event NewGameEventDel NewGameEventEvent;
   
    private void Start()
    {
        Stamp.PushOnStampEvent += PushOnStamp;
        ChangeGameState();
        NewEventCreated();
    }
    private void OnDestroy()
    {
        Stamp.PushOnStampEvent -= PushOnStamp;
    }
    private void PushOnStamp(Stamp s)
    {
        if(s.StampColor == StampColor.Green)
        {           
            gameEventData.Completed = Completed.Yes;
            gameEventData.Decision = Decision.Green;
        }
        if (s.StampColor == StampColor.Red)
        {
            gameEventData.Completed = Completed.Yes;
            gameEventData.Decision = Decision.Red;
        }
    }
    private void ChangeGameState()
    {
        GameCore.INSTANCE.StateMashine.CurrentGameState = GameState.Event;
    }

    private void NewEventCreated()
    {
        if(NewGameEventEvent != null)
        {
            NewGameEventEvent(this);
        }
    }

}
