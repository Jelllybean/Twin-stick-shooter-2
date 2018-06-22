using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour {

    [SerializeField]
    private GameObject Speler;
    [SerializeField]
    private GameObject lift;
    [SerializeField]
    private AudioSource m_LiftMusic;
    [SerializeField]
    private PlayerController m_movement;

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Camera LiftCamera;

    bool FirstEnter;

    Vector3 speed;
    bool OnLift;
    void Start()
    {
        speed.y = 0.1f;
        FirstEnter = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (FirstEnter == true)
        {
            if (other.collider.tag == "Player")
            {
                Speler.transform.SetParent(transform);
                ActivateLift();
                MainCamera.enabled = false;
                LiftCamera.enabled = true;
                m_movement.enabled = false;
                OnLift = true;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Speler.transform.parent = null;
            OnLift = false;
            MainCamera.enabled = true;
            LiftCamera.enabled = false;
            m_movement.enabled = true;
            m_LiftMusic.Stop();
            FirstEnter = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (OnLift == true)
        {
            transform.position -= speed;
        }
    }

    public void ActivateLift()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnLift = true;
            m_LiftMusic.Play();
        }
    }
}
