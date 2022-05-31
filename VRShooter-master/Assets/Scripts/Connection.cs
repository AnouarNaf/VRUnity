using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;
using SimpleJSON;

namespace DatabaseConnection
{
    public class Connection : MonoBehaviour
    {
        public GameObject username;
        public GameObject password;
        public GameObject login;
        public Button btnLogin;

        [SerializeField] public UserSO user;


        private string UserName;
        private string Password;
        // Use this for initialization
        void Start()
        {
           

        }

        void Update()
        {
            UserName = username.GetComponent<InputField>().text;
            Password = password.GetComponent<InputField>().text;

            btnLogin = login.GetComponent<Button>();
            btnLogin.onClick.AddListener(validateLogin);
        }

        private void validateLogin()
        {
         if (UserName != "" && Password != "")
            {
                StartCoroutine(CallLogin(UserName, Password));
                //print("Login Success");
            }    
        }


        public IEnumerator CallLogin(string UserName, string Password)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", UserName);
            //form.AddField("password", Password);
            UnityWebRequest www = UnityWebRequest.Get("http://172.24.3.236:5001/manaiapi/Jugador/userdata/" + UserName);

            yield return www.Send();
            

            if (www.error != null)
            {
                Debug.Log("Error " + www.error);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            else
            {
                Debug.Log("Response " + www.downloadHandler.text);   

                JSONNode Info = JSON.Parse(www.downloadHandler.text);           
                string pass = Info["password"];            

                if (Password == pass) {
                    user.Value = UserName;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
                }
                
            }

        }

    }
   
}


