using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDoor : MonoBehaviour {




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KeyCard")
        {
            //KeyCardAquired = true;

        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
