using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using SimpleJSON;
using UnityEngine.Networking;



public class HighScoreTable : MonoBehaviour
{
    private Transform dataHSvariable;
    private Transform scoreHSvariable;
    private string user = APIController.usuari;
    private int score = APIController.puntu;
        

    //public IEnumerator getData() {

    //    UnityWebRequest llistaUrl = UnityWebRequest.Get("http://172.24.3.236:5001/manaiapi/Partida/scores/");
    //    yield return llistaUrl.Send();
        

    //    JSONNode Info = JSON.Parse(llistaUrl.downloadHandler.text);


    //    usuari = Info["userName"];
    //    puntu = Info["puntuation"];


    //    Debug.Log(llistaUrl.Send());

    //    Debug.Log(puntu);
    //    Debug.Log(Info);
    //    Debug.Log(usuari);
    //}

    //private void validate()
    //{
    //    StartCoroutine(getData());
    //}

    // Start is called before the first frame update
    private void Awake()
    {

        dataHSvariable = transform.Find("dataHS");
        scoreHSvariable = dataHSvariable.Find("scoreHS");

        

        float templateHeight = 100f;
        for (int i = 0; i < 5; i++)
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


            //Debug.Log(score);
            //Debug.Log(user);

            scoreHSvariable.Find("positionText").GetComponent<Text>().text = rankString;

            scoreHSvariable.Find("scoreText").GetComponent<Text>().text = score.ToString();

            scoreHSvariable.Find("userText").GetComponent<Text>().text = user;

        }
    }
}
