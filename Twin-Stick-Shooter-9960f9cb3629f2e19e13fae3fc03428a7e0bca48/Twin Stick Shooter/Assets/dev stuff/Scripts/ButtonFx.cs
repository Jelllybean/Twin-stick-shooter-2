using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Hoversound()
    {
        myFx.PlayOneShot(hoverSound);
    }
    
    public void ClickSound()
    {
        myFx.PlayOneShot(clickSound);
    }
}
