using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFinalPuntuation : MonoBehaviour
{
    [SerializeField] public TMP_Text puntuation;
    [SerializeField] public EnemiesSO EnemiesDefeated;

    // Start is called before the first frame update
    void Start()
    {
        puntuation.text = EnemiesDefeated.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
