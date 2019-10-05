using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightHead : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Text text;

    private void Awake()
    {
        GameEvent.NewGameEventEvent += CreatedNewGameEvent;
    }
    private void OnDestroy()
    {
        GameEvent.NewGameEventEvent -= CreatedNewGameEvent;
    }
    private void CreatedNewGameEvent(GameEvent ge)
    {
        GameSide gs = ge.GameSide;       
        image.GetComponent<Image>().sprite = gs.RandomFaceImage();
        text.text = gs.RandomName();
    }
}
