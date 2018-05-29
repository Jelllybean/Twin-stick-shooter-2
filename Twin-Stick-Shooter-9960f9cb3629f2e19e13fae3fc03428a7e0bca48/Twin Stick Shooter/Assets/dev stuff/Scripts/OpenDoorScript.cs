using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour {

    [SerializeField]
    private Animator Door;

    [SerializeField]
    private Animator KeyDoor;

    bool PlayerAtDoor;

    bool KeyCardLiftAquired;
    bool KeyCardAquired;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerAtDoor = true;
        }
        if (other.gameObject.tag == "KeyCard")
        {
            KeyCardAquired = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "KeyCardLift")
        {
            print("hoi");
            KeyCardLiftAquired = true;
            //Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        KeyCardAquired = false;
        KeyCardLiftAquired = false;
    }
    // Use this for initialization
    void Start ()
    {
        Door.GetComponent<Animator>();
        KeyDoor.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //print(KeyCardLiftAquired);
		//if (PlayerAtDoor == true)
  //      {
            if (KeyCardLiftAquired == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Door.SetBool("Open", true);
                }
            }
        //}
        if (KeyCardAquired == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                KeyDoor.SetBool("OpenDoor", true);
                //KeyDoor.SetBool("CloseDoor", false);
            }
        }
	}
}
