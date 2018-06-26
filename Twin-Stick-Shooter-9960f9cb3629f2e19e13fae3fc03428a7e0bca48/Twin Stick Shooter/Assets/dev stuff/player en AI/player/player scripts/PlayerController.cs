using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    private Rigidbody PlayerRigid;

    private Vector3 MoveInput;
    private Vector3 MoveVelocity;

    [SerializeField]
    private Camera MainCamera;

    [SerializeField]
    private GameObject Kogel;
    [SerializeField]
    private GameObject Bullet_Emitter;
    [SerializeField]
    private GameObject Crosshairs;
    [SerializeField]
    private float Bullet_force;
    float timer;
    [SerializeField]
    private int MaxShells;
    [SerializeField]
    bool PistolActive;
    [SerializeField]
    bool MachineGunActive;
    [SerializeField]
    bool ShotgunActive;

    [SerializeField]
    private GameObject DoorKey;
    [SerializeField]
    private GameObject DoorKeyLift;

    [SerializeField]
    private Text PistolAmmoCount;
    [SerializeField]
    private AudioSource m_GunCocking;
    [SerializeField]
    private AudioSource m_MachineGunCocking;

    [SerializeField]
    private GameObject PistolSprite;
    [SerializeField]
    private GameObject MachineGunSprite;

    int PistolAmmo;
    int MachineGunAmmo;
    int PistolAmmoReserve;
    int MachineGunReserve;

    bool ShotgunFired;
	void Start ()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        //MainCamera = FindObjectOfType<Camera>();

        PistolAmmo = 12;
        MachineGunAmmo = 30;
        PistolAmmoReserve = 36;
        MachineGunReserve = 90;

            Cursor.visible = false;

        Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PistolActive = true;
            ShotgunActive = false;
            MachineGunActive = false;
            m_GunCocking.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PistolActive = false;
            ShotgunActive = false;
            MachineGunActive = true;
            m_MachineGunCocking.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PistolActive = false;
            ShotgunActive = true;
            MachineGunActive = false;
        }
        //infinite ammo
        if (Input.GetKeyDown(KeyCode.J))
        {
            PistolAmmo = int.MaxValue;
            MachineGunAmmo = int.MaxValue;
        }

        MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        MoveVelocity = MoveInput * moveSpeed;

        Ray CameraRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        Plane worldPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (worldPlane.Raycast(CameraRay, out rayLength))
        {
            Vector3 pointToLook = CameraRay.GetPoint(rayLength);
            Debug.DrawLine(CameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            Bullet_Emitter.transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            Crosshairs.transform.position = (new Vector3(pointToLook.x, Crosshairs.transform.position.y, pointToLook.z));
        }

        if (PistolAmmoReserve <= 0)
        {
            PistolAmmoReserve = 0;
        }
        if (MachineGunReserve <= 0)
        {
            MachineGunReserve = 0;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        PlayerRigid.velocity = MoveVelocity;
        if (PistolActive == true)
        {
            Pistol();
        }
        if (ShotgunActive == true)
        {
            Shotgun();
        }
        if (MachineGunActive == true)
        {
            SubMachineGun();   
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PistolAmmo")
        {
            PistolAmmoReserve += 12;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "MachineGunAmmo")
        {
            MachineGunReserve += 30;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "KeyCard")
        {
            DoorKey.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "KeyCardLift")
        {
            DoorKeyLift.SetActive(true);
            Destroy(other.gameObject); 
        }
    }
    public void Pistol()
    {
        PistolSprite.SetActive(true);
        MachineGunSprite.SetActive(false);
        PistolAmmoCount.text =  PistolAmmo + " / " + PistolAmmoReserve;
        if (Input.GetKeyDown(KeyCode.R) && PistolAmmoReserve >= 0)
        {
            PistolAmmo = 12;
            PistolAmmoReserve -= 12;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (PistolAmmo > 0)
            {
                if (timer >= 0.2)
                {
                    PistolAmmo--;
                    Shoot();
                }
            }
        }
    }
    public void SubMachineGun()
    {
        PistolSprite.SetActive(false);
        MachineGunSprite.SetActive(true);
        PistolAmmoCount.text = "         " + MachineGunAmmo + " / " + MachineGunReserve;
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(MachineGunReserve <= 0)
            {
                return;
            }
            else
            {
                MachineGunAmmo = 30;
                MachineGunReserve -= 30;
            }

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (MachineGunAmmo > 0)
            {
                if (timer >= 0.2)
                {
                    MachineGunAmmo--;
                    Shoot();
                }
            }
        }
    }
    public void Shotgun()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (timer >= 0.5f)
            {
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

                Destroy(Temporary_Bullet_Handler, 5f);
                timer = 0;
                ShotgunFired = true;
  
            }
        }
    }
    public void Shoot()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 0);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

        Destroy(Temporary_Bullet_Handler, 5f);
        timer = 0;
    }
}
