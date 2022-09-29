using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level manager", menuName = "ScriptableObjects/new LevelManager", order = 1)]

public class SO_LevelManager : ScriptableObject
{
    public int levelPlayer;
    public int current_XP;

    public List<int> nextXPLevel;
}
