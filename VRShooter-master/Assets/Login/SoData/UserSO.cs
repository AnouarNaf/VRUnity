using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class UserSO : ScriptableObject
{
    [SerializeField] string user;

    public string Value
    {
        get { return user; }
        set { user = value; }
    }
}
