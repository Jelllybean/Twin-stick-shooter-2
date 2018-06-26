using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinElevator : MonoBehaviour {


    Vector3 speed;
	void Start ()
    {
        speed.y = 0.1f;
	}
	
    private void OnCollisionStay(Collision other)
    {   
        if(other.gameObject.tag == "Player")
        {
            transform.position += speed;
        }
    }
}
