using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNormalDoors : MonoBehaviour {

    [SerializeField]
    private Animator m_door;
    void Start()
    {
        m_door.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }
    private void OpenDoor()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            m_door.SetBool("Open", true);
        }
    }
    private void SetBoolFalse()
    {
        m_door.SetBool("Open", false);
    }
}
