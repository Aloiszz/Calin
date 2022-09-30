using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Chrono : MonoBehaviour
{
    public float timer;
    private float seconds;
    private float minutes;
    private float hours;

    public TextMeshProUGUI stopWatchText;
    
    
    public static Chrono instance;
    
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
