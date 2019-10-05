using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI INSTANCE;

    [SerializeField] GameObject resPanel;
    [SerializeField] GameObject leftHead;
    [SerializeField] GameObject rightHead;
    [SerializeField] GameObject dialogView;
    [SerializeField] GameObject redStampView;
    [SerializeField] GameObject greenStampView;
    [SerializeField] GameObject cityView;


    private void Awake()
    {
        INSTANCE = this;
        GameEvent.NewGameEventEvent += NewEventCreated;
    }
    private void OnDestroy()
    {
        GameEvent.NewGameEventEvent -= NewEventCreated;
    }
    private void NewEventCreated(GameEvent ge)
    {
        
    }
}
