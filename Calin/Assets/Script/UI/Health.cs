using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{

    public float health = 75f;
    public float maxHealth = 100f;

    public Image healthBarImage;
  //  public TextMeshProUGUI healthText;
   
    void Update()
    {
        healthBarImage.fillAmount = health / maxHealth;
  //    healthText.text = health + '/' + maxHealth;         
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
