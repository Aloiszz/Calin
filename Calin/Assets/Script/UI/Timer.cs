using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int tempsint;
    private float tps;

    private void Start()
    {
        tps = VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex];
    }

    void Update()
    {
        tempsint = Mathf.RoundToInt(VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex]);
        timerText.text = ("Prochaine vague dans : ") + tempsint;
        if (VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex] >= 0)
        {
            VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex] -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.vagueTimerIndex++; 
            //VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex] = tps;
            VagueManager.instance.isSpawn = true;
            
        }

        if (VagueManager.instance.lifeTimer[VagueManager.instance.lifeTimerIndex] >= 0)
        {
            VagueManager.instance.lifeTimer[VagueManager.instance.lifeTimerIndex] -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.lifeTimerIndex++; 
            VagueManager.instance.isSpawnCoeur = true;
        }
        
    }
}
