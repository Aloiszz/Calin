using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "Shotgun Base", menuName = "ScriptableObjects/new ShotGun Base", order = 1)]

public class SO_Shotgun : ScriptableObject
{
    [Header("Bullet Spec")]
     
    
    public List<float> number; // nombre de munitions instantié
    public int numberIndex;
    public List<float> cadency; // cadence de tir
    public int cadencyIndex;
    public List<float> velocity; // velocité de la munition
    public int velocityIndex;
    public List<int> axeShoot;
    public int axeShootIndex;

     // indexation a récupérer

    [Header(" ")]
    [Header("Level Player")] 
    public int levelPlayer;
    
    public List<float> bulletDamage; // direction du tir;
    public List<float> life;
    public List<float> xp;



}
