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
    private PlayerController m_move;

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Camera LiftCamera;

    Vector3 speed;
    bool OnLift;
    private void OnCollisionStay(Collision other)
    {

        if (OnLift == true)
        {
            if (other.collider.tag == "Player")
            {
                Speler.transform.SetParent(transform);
                MainCamera.enabled = false;
                LiftCamera.enabled = true;
                transform.position -= speed;
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
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void ActivateLift()
    {


    }
}
