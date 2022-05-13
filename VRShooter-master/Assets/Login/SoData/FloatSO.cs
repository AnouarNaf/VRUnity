using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class FloatSO : ScriptableObject
{
    [SerializeField] float user;

    public float Value
    {
        get { return user; }
        set { user = value; }
    }
}
