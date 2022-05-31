using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{

    [SerializeField] public TMP_Text time;
    [SerializeField] public IntSO seconds;
    public int secondLeft = 60;
    public bool takingAway = false;
    // Start is called before the first frame update
    void Start()
    {
        time.text = time.text + secondLeft;
        seconds.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        seconds.Value ++;

        time.text = secondLeft.ToString();
        if (secondLeft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        takingAway = false;
    }
}
