using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ScoreSO : ScriptableObject
{
    [SerializeField] int score;

    public int Value
    {
        get { return score; }
        set { score = value; }
    }
}


