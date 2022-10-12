using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;using TMPro;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public SO_PlayerController PlayerControllerSO;
    
    public Image life_Bar;
    public TextMeshProUGUI lifeTxt;
    private double life_Value;
    
    public int current_life;
    public int maxLife;
    public int nextLifeLevel;
    
    public static LifeManager instance;
    
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
        current_life = PlayerControllerSO.nextLifeLevel[XP_Manager.instance.levelPlayer];
        maxLife = current_life;
    }
    public void SecureSO()
    {
        nextLifeLevel = PlayerControllerSO.nextLifeLevel[XP_Manager.instance.levelPlayer];
    }
    
    private void Update()
    {
        //XP_Bar.fillAmount xp_Value= (current_XP % nextXPLevel) * 0.01f;
        
        //life_Value = () ;
        life_Bar.DOFillAmount((float)current_life / nextLifeLevel, 0.15f);
        
        lifeTxt.text = current_life + " / " + nextLifeLevel;

        Death();
    }
    

    public void Death()
    {
        if (current_life <= 0)
        {
            Destroy(PlayerController.instance.gameObject);
            GameManager.instance.AnnonceMort();
        }
    }
}
