using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private TextMeshProUGUI  score;

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        score.text = "EXP :  " + XP_Manager.instance.current_XP + " / "+ XP_Manager.instance.nextXPLevel;
    }  
}
                                