using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCard : MonoBehaviour {

    [SerializeField]
    private GameObject KeyCard;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.gameObject.tag = "KeyCard";
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
