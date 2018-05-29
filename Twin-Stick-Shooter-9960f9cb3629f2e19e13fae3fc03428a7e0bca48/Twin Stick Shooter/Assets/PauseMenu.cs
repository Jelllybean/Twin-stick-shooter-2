using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pausedMenuUI;
	
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
		
	}

     public void Resume()
    {
        pausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

     public void Pause()
    {
        pausedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen (proto)");
    }

    public void QuitGame()
    {
        Debug.Log("sayonara nigger");
        Application.Quit();
    }
}
