using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float temps = 120;
    public Text timerText;
    public int tempsint;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        tempsint = Mathf.RoundToInt(temps);
        timerText.text = ("Prochaine vague dans : ") + tempsint;
        if (temps >= 0)
        {
            temps -= Time.deltaTime;
        }
    }
}
