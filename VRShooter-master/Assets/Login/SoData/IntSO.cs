using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class IntSO : ScriptableObject
{
    [SerializeField] int puntuation;

    public int Value
    {
        get { return puntuation; }
        set { puntuation = value; }
    }
}


