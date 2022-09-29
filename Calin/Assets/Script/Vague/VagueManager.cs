using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagueManager : MonoBehaviour
{

    public GameObject Rush;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Rush, new Vector3(-10, -10, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
