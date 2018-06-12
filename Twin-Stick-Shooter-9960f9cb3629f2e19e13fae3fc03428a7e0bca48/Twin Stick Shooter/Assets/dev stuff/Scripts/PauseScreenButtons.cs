using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenButtons : MonoBehaviour {

    [SerializeField]
    private GameObject PauseScreen;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resume()
    {
        PauseScreen.SetActive(false);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen (proto)");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
