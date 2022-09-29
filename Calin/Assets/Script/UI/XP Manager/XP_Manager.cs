using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class XP_Manager : MonoBehaviour
{
    public SO_LevelManager XP_ManagerSO;

    public Image XP_Bar;
    private float xp_Value;

    public Text playerlevelTxt;

    public int levelPlayer;
    private int levelPlayer1 = 1;
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
        levelPlayer = XP_ManagerSO.levelPlayer;
        SecureSO();
    }

    private void Update()
    {
        //XP_Bar.fillAmount 
        xp_Value= (current_XP % nextXPLevel) * 0.01f;

        XP_Bar.DOFillAmount(xp_Value, 0.15f);
        //Debug.Log((current_XP % nextXPLevel) * 0.01f);
        
        LevelUp();
    }

    void SecureSO()
    {
        current_XP = XP_ManagerSO.current_XP;
        nextXPLevel = XP_ManagerSO.nextXPLevel[levelPlayer];
    }

    public void LevelUp()
    {
        playerlevelTxt.text = ("Niveau joueurs : ") + levelPlayer;

        if (current_XP > nextXPLevel)
        {
            levelPlayer++;
            SecureSO();
            _Rush();
        }
        
    }

    private GameObject[] _rushObjs;
    void _Rush()
    {
        _rushObjs = GameObject.FindGameObjectsWithTag("Rush");
        foreach (GameObject rush in _rushObjs)
        {
            rush.GetComponent<Rush>().levelPlayer++;
            rush.GetComponent<Rush>().SecureSO();
        }
        /*GameObject.FindGameObjectWithTag("Rush").GetComponent<Rush>().levelPlayer++;
        GameObject.FindGameObjectWithTag("Rush").GetComponent<Rush>().SecureSO();*/
        
        /*Rush.instance.levelPlayer++;
        Rush.instance.SecureSO();*/
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
