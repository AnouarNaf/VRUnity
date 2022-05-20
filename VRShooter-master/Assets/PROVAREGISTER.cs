using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PROVAREGISTER : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:5000/manaiapi/Jugador/register2", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}