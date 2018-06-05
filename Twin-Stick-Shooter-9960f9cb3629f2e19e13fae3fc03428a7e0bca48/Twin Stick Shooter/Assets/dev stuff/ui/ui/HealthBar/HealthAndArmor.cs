using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndArmor : MonoBehaviour
{ 
    private bool armordown;
    private int armorstrip;

    [SerializeField]
    private GameObject Player;
     
    [SerializeField]
    public HealthStat health;


    [SerializeField]
    private ArmorStat armor;

    bool PlayerHit;

    bool InfiniteHealth = false;

    bool ArmorDown;

    // Use this for initialization

    private void OnTriggerEnter(Collider item )
    {
        if (item.gameObject.tag == "Health")
        {
            if ( health.CurrentHealth < 100)
            {
                health.CurrentHealth += 100;
                item.gameObject.SetActive(false);
            }
        }
        if (item.gameObject.tag == "Armor")
        {
            if (armor.CurrentArmor < 100)
            {
                armor.CurrentArmor += 100;
                item.gameObject.SetActive(false);
            }
        }
        if (InfiniteHealth == false)
        {
            if (item.gameObject.tag == "EnemyBullet")
            {
                PlayerHit = true;
            }
        }

    }
    private void OnCollisionEnter(Collision other)
    {
       
    }
    void Start ()
    {
        armorstrip = 1;
        health.initialize();
        armor.initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(health.currentHealth);
        if(PlayerHit == true)
        {
            armor.CurrentArmor -= 40;
            PlayerHit = false;
            if (ArmorDown == true)
            {
                health.CurrentHealth -= 20;
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.CurrentHealth -= 10;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.CurrentHealth += 10;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            armor.CurrentArmor -= 10;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Doddamage(60);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            InfiniteHealth = !InfiniteHealth;
            health.currentHealth = float.MaxValue;
            armor.CurrentArmor = float.MaxValue;
        }
        //if (health.CurrentHealth <= 0)
        //{
        //    this.gameObject
        //}

        if(health.CurrentHealth <= 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("KilledByRobot", PlayerPrefs.GetInt("KilledByRobot") + 1);
            SceneManager.LoadScene("StartScreen (proto)");
        }
        
        if (armor.CurrentArmor <= 0)
        {
            ArmorDown = true;
        }

        
    }
    public void Doddamage( float damage)
    {
        float  doArmorDMG = 0 ;
        float  doHealthDMG = 0 ;
        if (armor.CurrentArmor < damage)
        {
            doHealthDMG = damage - armor.CurrentArmor;
            doArmorDMG = damage - doHealthDMG;
            armor.CurrentArmor -= doArmorDMG;
            health.CurrentHealth -= doHealthDMG;
        }
        else
        {
            armor.CurrentArmor -= damage;
        }
       


        


    }
}
