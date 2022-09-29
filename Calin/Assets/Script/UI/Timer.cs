using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public int tempsint;
    private float tps;

    private void Start()
    {
        tps = VagueManager.instance.vagueTimer;
    }

    void Update()
    {
        tempsint = Mathf.RoundToInt(VagueManager.instance.vagueTimer);
        timerText.text = ("Prochaine vague dans : ") + tempsint;
        if (VagueManager.instance.vagueTimer >= 0)
        {
            VagueManager.instance.vagueTimer -= Time.deltaTime;
        }
        else
        {
            VagueManager.instance.vagueTimer = tps;
            VagueManager.instance.isSpawn = true;
        }
        
    }
}
