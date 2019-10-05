using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogView : MonoBehaviour
{
    [SerializeField] Text text;
    GameEvent currentGameEvent;

    private void Awake()
    {
        GameEvent.NewGameEventEvent += CreatedNewGameEvent;
        Stamp.PushOnStampEvent += PushOnStamp;
    }
    private void OnDestroy()
    {
        GameEvent.NewGameEventEvent -= CreatedNewGameEvent;
        Stamp.PushOnStampEvent -= PushOnStamp;
    }
    private void CreatedNewGameEvent(GameEvent ge)
    {
        currentGameEvent = ge;
        text.text = ge.GameEventData.StartEventText;
    }
    private void PushOnStamp(Stamp s)
    {
        if (currentGameEvent.GameEventData.Completed == Completed.No)
        {
            if (s.StampColor == StampColor.Green)
            {
                text.text = currentGameEvent.GameEventData.PositiveEventText;
            }
            if (s.StampColor == StampColor.Red)
            {
                text.text = currentGameEvent.GameEventData.NegativeEventText;
            }
        }
    }
}
