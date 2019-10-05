using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTurn : MonoBehaviour
{
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Clk);
    }
    private void Clk()
    {
        GameCore.INSTANCE.StateMashine.CurrentGameState = GameState.StartTurn;
    }

}
