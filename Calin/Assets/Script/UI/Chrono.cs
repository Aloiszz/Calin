using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Chrono : MonoBehaviour
{
    public float timer;
    private int seconds;
    private int minutes;
    private int hours;

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
        int seconds =(int) timer % 60;
        int minutes = (int)(timer / 60) % 60;
        int hours = (int)(timer / 3600) % 24;

        stopWatchText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
