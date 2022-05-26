using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowFinalPuntuation : MonoBehaviour
{
    [SerializeField] public TMP_Text puntuation;
    [SerializeField] public TMP_Text second;
    [SerializeField] public TMP_Text enemies;
    [SerializeField] public EnemiesSO EnemiesDefeated;
    [SerializeField] public EnemiesSO difficulty;
    [SerializeField] public UserSO user;
    [SerializeField] public ScoreSO score;
    [SerializeField] public IntSO time;


    private string UserName;
    private int Puntuation;
    private int seconds;
    private int defeated;

    // Start is called before the first frame update
    void Start()
    {
        switch (difficulty.Value)
        {
            case 4:
                Puntuation = score.Value * 3;
                break;
            case 3:
                Puntuation = score.Value * 2;
                break;
            default:
                break;
        }
        Debug.Log("UwU");
        puntuation.text = "Score:    " + Puntuation;
        second.text = "Time:    " + time.Value.ToString();
        enemies.text = "Enemies Defeateds:    " + EnemiesDefeated.Value.ToString();
        UserName = user.Value;
        seconds = time.Value;
        defeated = EnemiesDefeated.Value;
        StartCoroutine(SendGame(UserName, Puntuation, seconds, defeated));
    }
    private void Update()
    {

    }

    public IEnumerator SendGame(string User, int Score, int Time, int Defeated)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", User);
        form.AddField("puntuation", Score);
        form.AddField("time", Time);
        form.AddField("enemiesdefeated", Defeated);

        UnityWebRequest www = UnityWebRequest.Post("http://172.24.3.236:5001/manaiapi/Partida/scores", form);

        yield return www.SendWebRequest();


        if (www.error != null)
        {
            Debug.Log("Error " + www.error);

        }
        else
        {
            Debug.Log("Response " + www.downloadHandler.text);
        }
    }
}
