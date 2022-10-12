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
        //RUSH
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
        //RUSH END
        // RUSH 2
        if (VagueManager.instance.vagueTimer2[VagueManager.instance.vagueTimerIndex2] >= 0)
        {
            VagueManager.instance.vagueTimer2[VagueManager.instance.vagueTimerIndex2] -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.vagueTimerIndex2++; 
            //VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex] = tps;
            VagueManager.instance.isSpawn2 = true;
            
        }
        //END RUSH 2
        // RUSH 3
        if (VagueManager.instance.vagueTimer3[VagueManager.instance.vagueTimerIndex3] >= 0)
        {
            VagueManager.instance.vagueTimer3[VagueManager.instance.vagueTimerIndex3] -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.vagueTimerIndex3++; 
            //VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex] = tps;
            VagueManager.instance.isSpawn3 = true;
            
        }
        //END RUSH 3
        // RUSH 4
        if (VagueManager.instance.vagueTimer4[VagueManager.instance.vagueTimerIndex4] >= 0)
        {
            VagueManager.instance.vagueTimer4[VagueManager.instance.vagueTimerIndex4] -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.vagueTimerIndex4++; 
            //VagueManager.instance.vagueTimer[VagueManager.instance.vagueTimerIndex] = tps;
            VagueManager.instance.isSpawn4 = true;
            
        }
        //END RUSH 4
        //LIFE
        if (VagueManager.instance.lifeTimer[VagueManager.instance.lifeTimerIndex] >= 0)
        {
            VagueManager.instance.lifeTimer[VagueManager.instance.lifeTimerIndex] -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.lifeTimerIndex++; 
            VagueManager.instance.isSpawnCoeur = true;
        }
        //LIFE END
        
        //NUKE
        if (VagueManager.instance.NUKETimer[VagueManager.instance.NUKETimerIndex] >= 0)
        {
            VagueManager.instance.NUKETimer[VagueManager.instance.NUKETimerIndex] -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.NUKETimerIndex++; 
            VagueManager.instance.isSpawnNUKE = true;
        }
        //NUKE END
    }
}
