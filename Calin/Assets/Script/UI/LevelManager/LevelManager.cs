using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void LevelUp()
    {
        Rush.instance.levelPlayer++;
        Rush.instance.SecureSO();
        Debug.Log(Rush.instance.levelPlayer);
    }
    public void AxeDeTire()
    {
        Shotgun.instance.axeShootIndex++;
        Shotgun.instance.SecureSO();
        Debug.Log(Shotgun.instance.axeShootIndex);
    }
    
    public void AddVelocity()
    {
        Shotgun.instance.velocityIndex++;
        Shotgun.instance.SecureSO();
    }
    
    public void AddCadency()
    {
        Shotgun.instance.cadencyIndex++;
        Shotgun.instance.SecureSO();
    }
    
    public void AddNumber()
    {
        Shotgun.instance.numberIndex++;
        Shotgun.instance.SecureSO();
    }
    
}
