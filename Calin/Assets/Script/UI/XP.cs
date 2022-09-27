using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XP : MonoBehaviour
{
    private Image experienceBar;
    private Text playerLevelText;
    public int playerLevel = 1;
    public float currentXP = 0;
    public float maxXP = 100;
    public float rateXP;
    void Start()
    {
        experienceBar = GameObject.Find("CurrentXP").GetComponent<Image>();
        playerLevelText = GameObject.Find("PlayerLevelText").GetComponent<Text>();
    }

    
    void Update()
    {
        // A Supprimé
        if (Input.GetKeyDown(KeyCode.L))
        {
            currentXP += 50;
        }
        // A Supprimé
        
        if (currentXP >= maxXP)
        {                                               //Si on a assez d'XP
            float reste = currentXP - maxXP;
            playerLevel += 1;
            playerLevelText.text = "Level : " + playerLevel;
            currentXP = 0 + reste;
            maxXP = maxXP * rateXP;
        }
                                                        //La barre d'XP
        float percentageXP = ((currentXP * 100) / maxXP) / 100;
        experienceBar.fillAmount = percentageXP;
    }
}
