using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Transform head;
    [SerializeField] public TMP_Text Vida;
    [SerializeField] public TMP_Text Score;
    [SerializeField] public USUARI user;
    AudioSource audioData;
    private void Start()
    {
        user.Value = user.Value;
        Debug.Log(user.Value);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Vida.text = health.ToString();
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.LogError(string.Format("Player health: {0}",health));
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }
}
