using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerRes : MonoBehaviour
{
    [SerializeField] Fraction fraction;
    [SerializeField] Text text;
    [SerializeField] GameEvent currentGameEvent;

    private void Start()
    {
        text.text = GameCore.INSTANCE.BaseResValue.ToString();

        GameEvent.NewGameEventEvent += NewGameEvent;
        Stamp.PushOnStampEvent += PushOnStamp;
    }
    private void OnDestroy()
    {
        GameEvent.NewGameEventEvent -= NewGameEvent;
        Stamp.PushOnStampEvent -= PushOnStamp;
    }
    private void NewGameEvent(GameEvent ge)
    {
        currentGameEvent = ge;
    }
    private void PushOnStamp(Stamp s)
    {
        if (currentGameEvent.GameEventData.Completed == Completed.No)
        {
            int x = Int32.Parse(text.text);

            if (s.StampColor == StampColor.Red)
            {
                if (fraction == Fraction.Angel)
                {
                    x += currentGameEvent.GameEventData.NegativeAngel;
                }
                if (fraction == Fraction.Demon)
                {
                    x += currentGameEvent.GameEventData.NegativeDemon;
                }
                if (fraction == Fraction.Neutral)
                {
                    x += currentGameEvent.GameEventData.NegativeNeutral;
                }
                if (fraction == Fraction.Player)
                {
                    x += currentGameEvent.GameEventData.NegativePlayer;
                }
            }
            if (s.StampColor == StampColor.Green)
            {
                if (fraction == Fraction.Angel)
                {
                    x += currentGameEvent.GameEventData.PositiveAngel;
                }
                if (fraction == Fraction.Demon)
                {
                    x += currentGameEvent.GameEventData.PositiveDemon;
                }
                if (fraction == Fraction.Neutral)
                {
                    x += currentGameEvent.GameEventData.PositiveNeutral;
                }
                if (fraction == Fraction.Player)
                {
                    x += currentGameEvent.GameEventData.PositivePlayer;
                }
            }
            text.text = x.ToString();
        }
    }
}
