using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }
    
    void Update()
    {
        score.text = "Score :  " + XP_Manager.instance.current_XP;
    }  
}
                                