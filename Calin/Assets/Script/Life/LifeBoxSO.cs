using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LifeBox", menuName = "ScriptableObjects/new LifeBox", order = 1)]

public class LifeBoxSO : ScriptableObject
{
    public List<int> heartValue;
}
