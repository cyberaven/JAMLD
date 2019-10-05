using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StampColor
{
    Red,
    Green
}

public class Stamp : MonoBehaviour
{
    [SerializeField] StampColor stampColor;

    public StampColor StampColor { get => stampColor; set => stampColor = value; }

    public delegate void PushOnStampDel(Stamp s);
    public static event PushOnStampDel PushOnStampEvent;

    private void OnMouseDown()
    {
        Debug.Log("На меня нажали " + stampColor.ToString());
        if(PushOnStampEvent != null)
        {
            PushOnStampEvent(this);
        }
    }
}
