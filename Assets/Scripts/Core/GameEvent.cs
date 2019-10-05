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

    //[SerializeField] Completed completed = Completed.No;
    //public Completed Completed { get => completed; set => completed = value; }

    //[SerializeField] Decision decision;
    //public Decision Decision { get => decision; set => decision = value; }
    //public string StartEventText { get => startEventText; set => startEventText = value; }


    //[SerializeField] GameSide gameSide;
    //public GameSide GameSide { get => gameSide; set => gameSide = value; }
    //public string PositiveEventText { get => positiveEventText; set => positiveEventText = value; }
    //public string NegativeEventText { get => negativeEventText; set => negativeEventText = value; }
    //public int PositiveAngel { get => positiveAngel; set => positiveAngel = value; }
    //public int PositiveDemon { get => positiveDemon; set => positiveDemon = value; }
    //public int PositiveNeutral { get => positiveNeutral; set => positiveNeutral = value; }
    //public int PositivePlayer { get => positivePlayer; set => positivePlayer = value; }
    //public int NegativeAngel { get => negativeAngel; set => negativeAngel = value; }
    //public int NegativeDemon { get => negativeDemon; set => negativeDemon = value; }
    //public int NegativeNeutral { get => negativeNeutral; set => negativeNeutral = value; }
    //public int NegativePlayer { get => negativePlayer; set => negativePlayer = value; }

    //[SerializeField] string startEventText;
    //[SerializeField] string positiveEventText;
    //[SerializeField] string negativeEventText;

    //[SerializeField] int positiveAngel;
    //[SerializeField] int positiveDemon;
    //[SerializeField] int positiveNeutral;
    //[SerializeField] int positivePlayer;

    //[SerializeField] int negativeAngel;
    //[SerializeField] int negativeDemon;
    //[SerializeField] int negativeNeutral;
    //[SerializeField] int negativePlayer;


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
