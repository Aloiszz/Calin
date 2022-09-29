using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using DG.Tweening;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public CanvasGroup baseCanvas;
    public CanvasGroup pause;
    public CanvasGroup amelioration;
    public Volume globalVolume;
    
    public static GameManager instance;
    
    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
        } 
        else 
        { 
            instance = this; 
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        pause.DOFade(1, 0.5f);
        baseCanvas.DOFade(0, 0.5f);
        globalVolume.enabled = false;
        StartCoroutine(PauseTime());
    }
    public void UnPause()
    {
        pause.DOFade(0, 0.5f);
        baseCanvas.DOFade(1, 0.5f); 
        globalVolume.enabled = true;
        StartCoroutine(UnPauseTime());
    }
    
    IEnumerator PauseTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
    IEnumerator UnPauseTime()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.5f);
    }

    public void Amelioration()
    {
        globalVolume.enabled = false;
        baseCanvas.DOFade(0, 0.5f);
        amelioration.DOFade(1, 0.5f);
        StartCoroutine(PauseTime());
    }

    public void UnAmelioration()
    {
        globalVolume.enabled = true;
        baseCanvas.DOFade(1, 0.5f);
        amelioration.DOFade(0, 0.5f);
        StartCoroutine(UnPauseTime());
    }

    public void BtnAmelioration1()
    {

        UnAmelioration();
    }
    
    public void BtnAmelioration2()
    {
        
        UnAmelioration();
    }
    
    public void BtnAmelioration3()
    {

        UnAmelioration();
    }
    
    /*-------------------------Amelioration-----------------------------------------*/
    public void AxeDeTire()
    {
        if (Shotgun.instance.axeShootIndex < Shotgun.instance.shotgun_SO.axeShoot.Count)
        {
            Shotgun.instance.axeShootIndex++;
        }
        Shotgun.instance.SecureSO();
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
