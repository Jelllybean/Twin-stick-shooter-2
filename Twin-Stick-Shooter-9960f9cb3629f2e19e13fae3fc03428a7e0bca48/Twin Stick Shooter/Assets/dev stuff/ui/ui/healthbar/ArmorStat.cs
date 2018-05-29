using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ArmorStat
{

    [SerializeField]
    private Armor Abar;

    [SerializeField]
    private float maxArmor;

    [SerializeField]
    private float currentArmor;

    // dit is de huidige value van de healthbar die de speler op dat moment heeft 
    public float CurrentArmor
    {
        get
        {
            return currentArmor;
        }

        set
        {

            currentArmor = value;
            Abar.Value = currentArmor;
        }
    }

    public float MaxValue
    {
        get
        {
            return maxArmor;
        }

        set
        {

            maxArmor = value;
            Abar.MaxValue = value;
        }
    }
    public void initialize()
    {
        this.MaxValue = maxArmor;
        this.CurrentArmor = currentArmor;
    }
}
