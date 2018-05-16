﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Stats

{
    [SerializeField]
    private Healthbar bar;

    [SerializeField]
    private float maxhealth;

    [SerializeField]
    private float currentHealth;

    // dit is de huidige value van de healthbar die de speler op dat moment heeft 
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {

            currentHealth = Mathf.Clamp(value, 0, MaxValue);
            bar.Value = currentHealth;
        }
    }

    public float MaxValue
    {
        get
        {
            return maxhealth;
        }

        set
        {

            maxhealth = value;
            bar.Value = value;
        }
    }
    public void initialize()
    {
        this.MaxValue = maxhealth;
        this.CurrentHealth = currentHealth;
    }
}
