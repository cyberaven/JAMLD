using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "GameEventData", menuName = "GameEventData", order = 51)]
public class GameEventData : ScriptableObject
{

    [SerializeField] Completed completed = Completed.No;
    public Completed Completed { get => completed; set => completed = value; }

    [SerializeField] Decision decision;
    public Decision Decision { get => decision; set => decision = value; }
    public string StartEventText { get => startEventText; set => startEventText = value; }


    [SerializeField] GameSide gameSide;
    public GameSide GameSide { get => gameSide; set => gameSide = value; }
    public string PositiveEventText { get => positiveEventText; set => positiveEventText = value; }
    public string NegativeEventText { get => negativeEventText; set => negativeEventText = value; }
    public int PositiveAngel { get => positiveAngel; set => positiveAngel = value; }
    public int PositiveDemon { get => positiveDemon; set => positiveDemon = value; }
    public int PositiveNeutral { get => positiveNeutral; set => positiveNeutral = value; }
    public int PositivePlayer { get => positivePlayer; set => positivePlayer = value; }
    public int NegativeAngel { get => negativeAngel; set => negativeAngel = value; }
    public int NegativeDemon { get => negativeDemon; set => negativeDemon = value; }
    public int NegativeNeutral { get => negativeNeutral; set => negativeNeutral = value; }
    public int NegativePlayer { get => negativePlayer; set => negativePlayer = value; }

    [SerializeField] string startEventText;
    [SerializeField] string positiveEventText;
    [SerializeField] string negativeEventText;

    [SerializeField] int positiveAngel;
    [SerializeField] int positiveDemon;
    [SerializeField] int positiveNeutral;
    [SerializeField] int positivePlayer;

    [SerializeField] int negativeAngel;
    [SerializeField] int negativeDemon;
    [SerializeField] int negativeNeutral;
    [SerializeField] int negativePlayer;
}
