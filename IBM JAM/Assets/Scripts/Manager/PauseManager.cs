using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public bool     paused;
    public Button   pauseButton,
                    continueButton,
                    restartButton,
                    quitButton;
    public Vector3  pauseMenuPos,
                    offPos;
    public Texture  continueTexture,
                    restartTexture,
                    quitTexture;

	void Start ()
    {
        paused = false;
        pauseMenuPos = GameObject.Find("PauseMenu").transform.position;
        offPos.x = 9999f; offPos.y = 9999f; offPos.z = 9999f;
    }

    void CheckPauseButton()
    {
        pauseButton = GameObject.Find("Pause").GetComponent<Button>();
        pauseButton.onClick.AddListener(TogglePauseGame);
    }

    void TogglePauseGame()
    {
        if (paused == false)
        {
            paused = true;
        }
    }

    void OnGUI()
    {
        if (paused)
        {
            Time.timeScale = 0f;
            GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = true;
            GameObject.Find("PauseMenu").transform.position = pauseMenuPos;

            GUILayout.BeginArea(new Rect(Screen.width / 2 - 188.5f, Screen.height / 2 - Screen.height / 6, 377f, 57f));

            if (GUILayout.Button(continueTexture))
            {
                ContinueGame();
            }

            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(Screen.width / 2 - 153.5f, Screen.height / 2, 307f, 57f));

            if (GUILayout.Button(restartTexture))
            {
                RestartGame();
            }

            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(Screen.width / 2 - 87.5f, Screen.height / 2 + Screen.height / 6, 175f, 68f));

            if (GUILayout.Button(quitTexture))
            {
                QuitGame();
            }

            GUILayout.EndArea();
        }
        else
        {
            Time.timeScale = 1f;
            GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
            GameObject.Find("PauseMenu").transform.position = offPos;
        }
    }

    void ContinueGame()
    {
        paused = false;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void Update ()
    {
        CheckPauseButton();
	}
}
