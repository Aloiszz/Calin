using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float temps = 120;
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
            temps -= Time.deltaTime;
        }
        else
        {
            temps = tps;
            VagueManager.instance.isSpawn = true;
        }
        
    }
}
