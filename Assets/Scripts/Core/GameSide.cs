using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum Fraction
{
    Angel,
    Demon,
    Neutral,
    Player
}

public class GameSide : MonoBehaviour
{
    [SerializeField] Fraction fraction;
    public Fraction Fraction { get => fraction; set => fraction = value; }

    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<string> names;

    public Sprite RandomFaceImage()
    {
        return sprites[UnityEngine.Random.Range(0, sprites.Count)];
    }
    public string RandomName()
    {
        return names[UnityEngine.Random.Range(0, names.Count)];
    }
}
