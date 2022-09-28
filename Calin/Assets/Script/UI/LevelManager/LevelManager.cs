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
        if (Shotgun.instance.axeShootIndex < Shotgun.instance.shotgun_SO.axeShoot.Count)
        {
            Shotgun.instance.axeShootIndex++;
        }
        Shotgun.instance.SecureSO();
        Debug.Log(Shotgun.instance.axeShootIndex);
    }
    
    public void AddVelocity()
    {
        if (Shotgun.instance.velocityIndex < Shotgun.instance.shotgun_SO.velocity.Count)
        {
            Shotgun.instance.velocityIndex++;
        }
        Shotgun.instance.SecureSO();
    }
    
    public void AddCadency()
    {
        if (Shotgun.instance.cadencyIndex < Shotgun.instance.shotgun_SO.cadency.Count)
        {
            Shotgun.instance.cadencyIndex++;
        }
        Shotgun.instance.SecureSO();
    }
    
    public void AddNumber()
    {
        if (Shotgun.instance.numberIndex < Shotgun.instance.shotgun_SO.number.Count)
        {
            Shotgun.instance.numberIndex++;
        }
        Shotgun.instance.SecureSO();
    }
    
}
