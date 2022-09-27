using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chrono : MonoBehaviour
{
    public float chronometre;
    void Start()
    {
        chronometre = 10;
    }

    // Update is called once per frame
    void Update()
    {
        chronometre = chronometre - Time.deltaTime;
        Debug.Log(chronometre);
    }
}
