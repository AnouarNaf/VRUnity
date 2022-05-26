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
    public class Connection1 : MonoBehaviour
    {
        public GameObject username;
        public GameObject password;
        public GameObject login;
        public GameObject surname;
        public GameObject email;
        public GameObject name;

        public Button btnLogin;


        private string UserName;
        private string Password;
        private string Surname;
        private string Name;
        private string Email;

        // Use this for initialization
        void Start()
        {

        }

        void Update()
        {
            UserName = username.GetComponent<InputField>().text;
            Name = name.GetComponent<InputField>().text;
            Surname = surname.GetComponent<InputField>().text;
            Password = password.GetComponent<InputField>().text;
            Email = email.GetComponent<InputField>().text;
            btnLogin = login.GetComponent<Button>();
            btnLogin.onClick.AddListener(validateRegister);
        }

        private void validateRegister()
        {
            if (UserName != "" && Password != "" && Name != "" && Surname != "" && Email != "")
            {
                StartCoroutine(CallRegister(UserName, Name, Surname, Password, Email));
                
            }
        }


        public IEnumerator CallRegister(string UserName, string Name, string Surname, string Password, string Email)
        {

            WWWForm form = new WWWForm();
            form.AddField("username", UserName);
            form.AddField("password", Password);
            form.AddField("name", Name);
            form.AddField("surname", Surname);
            form.AddField("mail", Email);


            UnityWebRequest www = UnityWebRequest.Post("http://172.24.3.236:5001/manaiapi/Jugador", form);

            yield return www.SendWebRequest();

            


            if (www.error != null)
            {
                Debug.Log("Error " + www.error);

            }
            else
            {
                Debug.Log("Response " + www.downloadHandler.text);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }

        }

    }


