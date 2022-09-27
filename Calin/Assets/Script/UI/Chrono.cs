using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrono : MonoBehaviour
{
    public float timer;
    private float seconds;
    private float minutes;
    private float hours;

    [SerializeField] private Text stopWatchText;
    void Start()
    {
        timer = 0;
    }
    
    void Update()
    {
        StopWatchCalcul();
    }

    void StopWatchCalcul()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
        minutes = timer / 60;
        hours = timer / 3600;

        stopWatchText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
