using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // player health 
    [SerializeField]
    private Stats health; 

    // Use this for initialization
    void Start ()
    {
        health.initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.CurrentHealth -= 10;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.CurrentHealth += 10;
        }
    }
}
