using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class USUARI : ScriptableObject
{
    [SerializeField] string Usuari;

    public string Value
    {
        get { return Usuari; }
        set { Usuari = value; }
    }
}
