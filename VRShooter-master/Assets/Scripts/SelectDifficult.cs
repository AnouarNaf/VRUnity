using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficult : MonoBehaviour
{
    [SerializeField] public EnemiesSO enemies;
    [SerializeField] public USUARI user;
    public void Start()
    {
        user.Value = user.Value;
        Debug.Log(user.Value);
    }

    public void GoEasy()
    {
        enemies.Value = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoMedium()
    {
        enemies.Value = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoDifficult()
    {
        enemies.Value = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

