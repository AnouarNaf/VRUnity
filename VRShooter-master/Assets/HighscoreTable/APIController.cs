using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;



public class APIController : MonoBehaviour
{
    public static string usuari;
    public static int puntu;


        public IEnumerator getData()
        {

        using (UnityWebRequest llistaUrl = UnityWebRequest.Get("http://172.24.3.236:5001/manaiapi/Partida/scores/"))
        {
            yield return llistaUrl.Send();


            JSONNode Info = JSON.Parse(llistaUrl.downloadHandler.text);

            string usuari = Info["userName"];
            int puntu = Info["puntuation"];

            Debug.Log(llistaUrl.Send());

            if (llistaUrl.isNetworkError || llistaUrl.isHttpError)
            {
                Debug.Log(llistaUrl.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }

        }
    }

        private void validate()
        {
            StartCoroutine(getData());
        }
    }