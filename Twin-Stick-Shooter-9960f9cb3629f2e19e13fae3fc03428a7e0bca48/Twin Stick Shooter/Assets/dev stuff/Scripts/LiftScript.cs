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
<<<<<<< HEAD
    private PlayerController m_move;
=======
    private PlayerController m_movement;
>>>>>>> ca00ccce9320ebb5686ea02ce7ee0cc2df1a8171

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Camera LiftCamera;

    bool FirstEnter;

    Vector3 speed;
    bool OnLift;
    void Start()
    {
<<<<<<< HEAD

        if (OnLift == true)
=======
        speed.y = 0.1f;
        FirstEnter = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (FirstEnter == true)
>>>>>>> ca00ccce9320ebb5686ea02ce7ee0cc2df1a8171
        {
            if (other.collider.tag == "Player")
            {
                Speler.transform.SetParent(transform);
<<<<<<< HEAD
                MainCamera.enabled = false;
                LiftCamera.enabled = true;
                transform.position -= speed;
=======
                ActivateLift();
                MainCamera.enabled = false;
                LiftCamera.enabled = true;
                m_movement.enabled = false;
                OnLift = true;
>>>>>>> ca00ccce9320ebb5686ea02ce7ee0cc2df1a8171
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
<<<<<<< HEAD
            m_move.enabled = true;
            m_LiftMusic.Stop();
            OnLift = false;
        }
    }
    void Start ()
    {
        m_move.enabled = false;
        speed.y = 0.1f;
        OnLift = true;
        m_LiftMusic.Play();
    }
=======
            m_movement.enabled = true;
            m_LiftMusic.Stop();
            FirstEnter = false;
        }
    }
>>>>>>> ca00ccce9320ebb5686ea02ce7ee0cc2df1a8171
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void ActivateLift()
    {


    }
}
