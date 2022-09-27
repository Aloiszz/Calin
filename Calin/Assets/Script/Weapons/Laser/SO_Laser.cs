using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Laser : MonoBehaviour
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

    public List<float> rayon; //largeur du tir


    [Header("Laser Spec")] public float incidenceAngle; //incidence angle pour le tir

}

