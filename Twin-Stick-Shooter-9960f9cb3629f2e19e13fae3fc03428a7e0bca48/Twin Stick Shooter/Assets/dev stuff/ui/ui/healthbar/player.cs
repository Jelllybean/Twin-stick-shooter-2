using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     
    
    public HealthStat health;


    [SerializeField]
    private ArmorStat armor;

	// Use this for initialization
	void Start ()
    {
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            armor.CurrentArmor -= 10;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            armor.CurrentArmor += 10;
        }
        if (Input.GetKeyDown(KeyCode.K) && armor.CurrentArmor <= 0)
        {
            health.CurrentHealth -= 10;
        }
    }
}
