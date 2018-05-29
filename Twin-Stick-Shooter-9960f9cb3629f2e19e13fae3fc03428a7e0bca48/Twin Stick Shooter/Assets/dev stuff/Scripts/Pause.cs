using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    private bool pause;
	void Start ()
    {
        pause = true;	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            print(pause);
            pause = !pause;
        }
	}

    public void PauseButton()
    {
        if(pause)
        {
            pause = false;
            //Time.timeScale = 1;
        }
        else
        {
            pause = true;
            //Time.timeScale = 0;
        }
    }
    public bool IsGamePaused()
    {
        return pause;
    }
}
