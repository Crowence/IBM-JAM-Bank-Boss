using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartExitGame : MonoBehaviour
{

    public Button   startButton,
                    exitButton;

	void Start ()
    {
        startButton = GameObject.Find("Start").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();
	}

    void StartGame()
    {
        SceneManager.LoadScene("Final");
    }

    void ExitGame()
    {
        Application.Quit();
    }
	
	void Update ()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
	}
}
