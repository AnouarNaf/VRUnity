using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using SimpleJSON;
using UnityEngine.Networking;

public class BestScore : MonoBehaviour
{
    private Transform dataHSvariable;
    private Transform scoreHSvariable;
    private string user;
    private int score;


    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(getData(user, score));

        dataHSvariable = transform.Find("dataHS");
        scoreHSvariable = dataHSvariable.Find("scoreHS");

        scoreHSvariable.gameObject.SetActive(false);

    }

    public IEnumerator getData(string user, int score)
    {

        UnityWebRequest llistaUrl = UnityWebRequest.Get("http://172.24.3.236:5001/manaiapi/Partida/scores/");

        yield return llistaUrl.Send();



        if (llistaUrl.isNetworkError || llistaUrl.isHttpError)
        {
            Debug.Log(llistaUrl.error);
        }
        else
        {
            
            float templateHeight = 100f;
            for (int i = 0; i < 9; i++)
            {
                Transform entryTransform = Instantiate(scoreHSvariable, dataHSvariable);
                RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                entryTransform.gameObject.SetActive(true);

                int rank = i + 1;
                string rankString;
                switch (rank)
                {
                    case 1: rankString = "1st"; break;
                    case 2: rankString = "2nd"; break;
                    case 3: rankString = "3rd"; break;

                    default: rankString = rank + "th"; break;
                }
                Debug.Log(rank);
                JSONNode Info = JSON.Parse(llistaUrl.downloadHandler.text);
                JSONArray Arrai = Info.AsArray;

                int scores = Arrai[i]["puntuation"];
                string users = Arrai[i]["userName"];

                yield return scores;
                yield return users;


                Debug.Log(users);
                Debug.Log(scores);
                //Debug.Log(score);
                //Debug.Log(user);

                scoreHSvariable.Find("positionText").GetComponent<Text>().text = rankString;

                scoreHSvariable.Find("scoreText").GetComponent<Text>().text = scores.ToString();

                scoreHSvariable.Find("userText").GetComponent<Text>().text = users;

            }
            //Debug.Log("Form upload complete!");
           
        }

    }
}
