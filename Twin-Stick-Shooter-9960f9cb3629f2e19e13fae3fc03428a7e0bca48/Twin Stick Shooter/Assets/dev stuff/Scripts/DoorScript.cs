using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {


    [SerializeField]
    private Animator Firstdoor;
    [SerializeField]
    private Animator ElevatorDoor;
	// Use this for initialization
	void Start ()
    {
        Firstdoor.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "KeyCard")
        {
            OpenFirstDoor();
        }
        if(other.gameObject.tag == "KeyCardLift")
        {
            OpenLiftDoor();
        }
    }
    private void OpenFirstDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Firstdoor.enabled = true;
        }
    }
    private void OpenLiftDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ElevatorDoor.enabled = true;
        }
    }
}
