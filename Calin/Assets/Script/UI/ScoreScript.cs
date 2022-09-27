using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    private Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }
    
    void Update()
    {
        score.text = "Score:" + scoreValue;
        // a supprimé
        if (Input.GetKeyDown(KeyCode.K))
        {
            scoreValue += 50;
        }  // a suprrimé
    }  
}
                                /*écrire dans le script des ennemis
                                ScoreScript.scoreValue += 10;    
                                10 étant le score obtenu lors d'un kill*/