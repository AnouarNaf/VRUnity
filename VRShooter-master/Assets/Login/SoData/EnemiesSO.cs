using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class EnemiesSO : ScriptableObject
{
    [SerializeField] int enemies;

    public int Value
    {
        get { return enemies; }
        set { enemies = value; }
    }
}

