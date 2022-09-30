using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Rush", menuName = "ScriptableObjects/new Rush", order = 1)]

public class SO_Rush : ScriptableObject
{
    [Header("Rush Spec")] 
    
    public int levelPlayer;
    
    public List<float> life;
    public List<float> velocity;
    public List<float> numberBullet;
    public List<int> xp;
    public List<int> damage;





    public List<float> timeCooldown;
    public int timeCooldownIndex;
    
    public float timeDestroyBullet;

    
    
}
