using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar_Script : MonoBehaviour
{
    private Image Healthbar;
    public float CurrentHealth;
    private float MaxHealth = 100f
    Health_Script Player;

    private void start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<Health_Script>();
    }

    private void Update()
    {
        CurrentHealth = Player.Health;
        Healthbar.fillAmount = CurrentHealth / MaxHealth;
    }
}
