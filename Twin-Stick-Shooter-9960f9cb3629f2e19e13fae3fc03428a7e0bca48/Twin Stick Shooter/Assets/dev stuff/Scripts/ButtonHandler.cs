using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class ButtonHandler : MonoBehaviour {

    [SerializeField]
    private string SceneToBeLoaded;
    [SerializeField]
    private Animator CameraAnimator;

    [SerializeField]
    private Text TimesDied;
    [SerializeField]
    private Text TimesPlayed;
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text TimesDiedByRobot;

	// Use this for initialization
	void Start () {
        CameraAnimator.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		//if (Input.GetKeyDown(KeyCode.Escape))
  //      {
  //          Cursor.visible = true;
  //          PauseScreen.SetActive(true);
  //          Time.timeScale = 0;
  //      }

        TimesDied.text = "Times died: " + PlayerPrefs.GetInt("TimesDied");
        TimesPlayed.text = "Times Played: " + PlayerPrefs.GetInt("TimesPlayed");
        Score.text = "Score: " + PlayerPrefs.GetInt("Score");
        TimesDiedByRobot.text = "Times killed by robot: " + PlayerPrefs.GetInt("KilledByRobot");
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Jelle Player");
        PlayerPrefs.SetInt("TimesPlayed", PlayerPrefs.GetInt("TimesPlayed") + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen (proto)");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        CameraAnimator.SetBool("GoToCredits", true);
        CameraAnimator.SetBool("GoToMenu", false);
        CameraAnimator.SetBool("GoToStats", false);
    }
    public void Menu()
    {
        CameraAnimator.SetBool("GoToCredits", false);
        CameraAnimator.SetBool("GoToMenu", true);
        CameraAnimator.SetBool("GoToStats", false);
    }
    public void Stats()
    {
        CameraAnimator.SetBool("GoToStats", true);
        CameraAnimator.SetBool("GoToCredits", false);
        CameraAnimator.SetBool("GoToMenu", false);
    }
}
