using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP_Manager : MonoBehaviour
{
    public SO_LevelManager XP_ManagerSO;

    public Image XP_Bar;

    public int levelPlayer;
    public int current_XP;
    public int nextXPLevel;
    
    public static XP_Manager instance;
    
    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
        } 
        else 
        { 
            instance = this; 
        }
    }
    private void Start()
    {
        SecureSO();
    }

    private void Update()
    {
        XP_Bar.fillAmount = (current_XP % nextXPLevel) * 0.01f;
        Debug.Log((current_XP % nextXPLevel) * 0.01f);
    }

    void SecureSO()
    {
        levelPlayer = XP_ManagerSO.levelPlayer;
        current_XP = XP_ManagerSO.current_XP;
        nextXPLevel = XP_ManagerSO.nextXPLevel[levelPlayer];
    }

    public void LevelUp()
    {
        _Rush();
    }

    void _Rush()
    {
        Rush.instance.levelPlayer++;
        Rush.instance.SecureSO();
    }
    
    
    /*------------------------------------------------------------------*/
    public void AxeDeTire()
    {
        if (Shotgun.instance.axeShootIndex < Shotgun.instance.shotgun_SO.axeShoot.Count)
        {
            Shotgun.instance.axeShootIndex++;
        }
        Shotgun.instance.SecureSO();
    }
    
    public void AddVelocity()
    {
        if (Shotgun.instance.velocityIndex < Shotgun.instance.shotgun_SO.velocity.Count)
        {
            Shotgun.instance.velocityIndex++;
        }
        Shotgun.instance.SecureSO();
    }
    
    public void AddCadency()
    {
        if (Shotgun.instance.cadencyIndex < Shotgun.instance.shotgun_SO.cadency.Count)
        {
            Shotgun.instance.cadencyIndex++;
        }
        Shotgun.instance.SecureSO();
    }
    
    public void AddNumber()
    {
        if (Shotgun.instance.numberIndex < Shotgun.instance.shotgun_SO.number.Count)
        {
            Shotgun.instance.numberIndex++;
        }
        Shotgun.instance.SecureSO();
    }
    
}
