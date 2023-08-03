using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scoring
{
    D = 50,
    C = 240,
    B = 420,
    A = 500
}

[System.Serializable]
public class Rating
{
    public string Username;
    public Scoring ScoreValue;
}
