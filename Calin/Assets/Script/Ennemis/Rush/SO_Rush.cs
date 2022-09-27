using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Rush", menuName = "ScriptableObjects/new Rush", order = 1)]

public class SO_Rush : ScriptableObject
{
    [Header("Rush Spec")] 
    public float life;


    public List<float> velocity;
    public int velocityIndex;

    public List<float> numberBullet;
    public int numberBulletIndex;

    public List<float> xp;
    public int xpIndex;
}
