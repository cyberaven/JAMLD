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
        if (currentGameEvent.Completed == Completed.No)
        {
            int x = Int32.Parse(text.text);

            if (s.StampColor == StampColor.Red)
            {
                if (fraction == Fraction.Angel)
                {
                    x += currentGameEvent.NegativeAngel;
                }
                if (fraction == Fraction.Demon)
                {
                    x += currentGameEvent.NegativeDemon;
                }
                if (fraction == Fraction.Neutral)
                {
                    x += currentGameEvent.NegativeNeutral;
                }
                if (fraction == Fraction.Player)
                {
                    x += currentGameEvent.NegativePlayer;
                }
            }
            if (s.StampColor == StampColor.Green)
            {
                if (fraction == Fraction.Angel)
                {
                    x += currentGameEvent.PositiveAngel;
                }
                if (fraction == Fraction.Demon)
                {
                    x += currentGameEvent.PositiveDemon;
                }
                if (fraction == Fraction.Neutral)
                {
                    x += currentGameEvent.PositiveNeutral;
                }
                if (fraction == Fraction.Player)
                {
                    x += currentGameEvent.PositivePlayer;
                }
            }
            text.text = x.ToString();
        }
    }
}
