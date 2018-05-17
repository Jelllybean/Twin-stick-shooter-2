using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    private bool armordown;
    private int armorstrip;
     
    [SerializeField]
    public HealthStat health;


    [SerializeField]
    private ArmorStat armor;

	// Use this for initialization
	void Start ()
    {
        armorstrip = 1;
        health.initialize();
        armor.initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
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
            Doddamage(40);
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
