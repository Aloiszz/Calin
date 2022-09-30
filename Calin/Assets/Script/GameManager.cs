using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Canvas baseCanvas;
    public Canvas pauseCanvas;
    public Canvas ameliorationCanvas;
    
    public CanvasGroup _base;
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
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Amelioration();
        }
    }

    void Pause()
    {
        pauseCanvas.enabled = true;
        baseCanvas.enabled = false;
        pause.DOFade(1, 0.5f);
        _base.DOFade(0, 0.5f);
        StartCoroutine(PauseTime());
    }
    public void UnPause()
    {
        StartCoroutine(UnPauseTime());
        baseCanvas.enabled = true;
        pauseCanvas.enabled = false;
        pause.DOFade(0, 0.5f);
        _base.DOFade(1, 0.5f);
    }

    public void MenuPrincipal()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    IEnumerator PauseTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
    IEnumerator UnPauseTime()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.5f);
    }

    public void Amelioration()
    {
        globalVolume.enabled = false;
        _base.DOFade(0, 0.5f);
        amelioration.DOFade(1, 0.5f);
        StartCoroutine(PauseTime());
    }

    public void UnAmelioration()
    {
        globalVolume.enabled = true;
        _base.DOFade(1, 0.5f);
        amelioration.DOFade(0, 0.5f);
        StartCoroutine(UnPauseTime());
    }

    public void BtnAmelioration1()
    {
        AxeDeTire();
    }
    
    public void BtnAmelioration2()
    {
        AddVelocity();
    }
    
    public void BtnAmelioration3()
    {
        AddNumber();
    }
    
    /*-------------------------Amelioration-----------------------------------------*/
    public void AxeDeTire()
    {
        UnAmelioration();
        if (Shotgun.instance.axeShootIndex < Shotgun.instance.shotgun_SO.axeShoot.Count)
        {
            Shotgun.instance.axeShootIndex++;
            Shotgun.instance.SecureSO();
        }
        
    }
    
    public void AddVelocity()
    {
        UnAmelioration();
        if (Shotgun.instance.velocityIndex < Shotgun.instance.shotgun_SO.velocity.Count)
        {
            Shotgun.instance.velocityIndex++;
            Shotgun.instance.SecureSO();
        }
    }
    
    public void AddCadency()
    {
        UnAmelioration();
        if (Shotgun.instance.cadencyIndex < Shotgun.instance.shotgun_SO.cadency.Count)
        {
            Shotgun.instance.cadencyIndex++;
            Shotgun.instance.SecureSO();
        }
        
    }
    
    public void AddNumber()
    {
        UnAmelioration();
        if (Shotgun.instance.numberIndex < Shotgun.instance.shotgun_SO.number.Count)
        {
            Shotgun.instance.numberIndex++;
            Shotgun.instance.SecureSO();
        }
        
    }
}
