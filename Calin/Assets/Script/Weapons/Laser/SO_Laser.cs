using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Laser base", menuName = "ScriptableObjects/new Laser Base", order = 1)]

public class SO_Laser : ScriptableObject 
{

    [Header("Bullet Spec")]
    public List<float> number; // nombre de munitions instantié
    public int numberIndex; // indexation a récupérer
    
    public List<float> cadency; // cadence de tir
    public int cadencyIndex; // indexation a récupérer
    
    public List<float> velocity; // velocité de la munition
    public int velocityIndex; // indexation a récupérer

    public List<string> aimAxes; // direction du tir;
    public int aimAxesIndex; // indexation a récupérer


    [Header("Laser Spec")] 
    public float incidenceAngle; //incidence angle pour le tir

}

