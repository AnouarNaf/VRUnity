using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    private Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(quitGame);
    }

    // Update is called once per frame
    private void quitGame()
    {
        print("UwU");
        Application.Quit();
    }
}
