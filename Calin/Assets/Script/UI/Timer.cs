using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float currentTime;
    public int startMinutes;
    public Text CurrentTimeText;

    private void Start()
    {
        currentTime = startMinutes * 60;
    }

    private void Update()
    {
        CurrentTimeText.text = currentTime.ToString();
    }
}
