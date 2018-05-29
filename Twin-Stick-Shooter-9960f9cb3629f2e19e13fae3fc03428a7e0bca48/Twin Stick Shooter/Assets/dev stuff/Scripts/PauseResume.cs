using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour {

    private Pause pause;
    private enum State { play, pause}
    private State state;
	void Start ()
    {
        pause = GameObject.Find("Pause").GetComponent<Pause>();
        state = State.play;

        NewStart();
	}

    virtual protected void NewStart()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(pause.IsGamePaused())
        {
            if(state == State.play)
            {
                state = State.pause;
                FirstPause();
            }
            PauseLoop();
        }
        else
        {
            if(state == State.pause)
            {
                state = State.play;
                FirstPlay();
            }
            GameLoop();
        }
	}
    virtual protected void PauseLoop()
    {

    }
    virtual protected void GameLoop()
    {

    }
    virtual protected void FirstPause()
    {

    }
    virtual protected void FirstPlay()
    {

    }
}
