using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
   private float time;
   public float TimerInterval = 5f;
   private float tick;

   private void Start()
   {
      
   }

   private void Update()
   {
      GetComponent<Text>().text = time.ToString();
      time = Time.time;
   }
}
