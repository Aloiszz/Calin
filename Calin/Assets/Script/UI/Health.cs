using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Health : MonoBehaviour
{

    public float health = 15f;
    public float maxHealth = 20f;
    private LineRenderer healthLine;

    public Image healthBarImage;


    void Update()
    {
        healthBarImage.fillAmount = health / maxHealth;
        //healthText.text = health + '/' + maxHealth;         
    }

    public void DamageButton(int damageAmount)
    {
        health -= damageAmount;
    }

    public void HealthButton(int healthAmount)
    {
        health += healthAmount;
    }
    
    
}

