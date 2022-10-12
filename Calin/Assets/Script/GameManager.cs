using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject basePanel;
    public GameObject pausePanel;
    public GameObject ameliorationPanel;
    public GameObject MortPanel;
    
    public CanvasGroup _base;
    public CanvasGroup pause;
    public CanvasGroup amelioration;
    public CanvasGroup mort;
    public Volume globalVolume;


    public TextMeshProUGUI txtIndicationDeath;
    
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
        pausePanel.SetActive(true);
        basePanel.SetActive(false);
        MortPanel.SetActive(false);
        pause.DOFade(1, 0.5f);
        _base.DOFade(0, 0.5f);
        StartCoroutine(PauseTime());
    }
    public void UnPause()
    {
        StartCoroutine(UnPauseTime());
        pausePanel.SetActive(false);
        basePanel.SetActive(true);
        MortPanel.SetActive(false);
        pause.DOFade(0, 0.5f);
        _base.DOFade(1, 0.5f);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
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
        basePanel.SetActive(false);
        ameliorationPanel.SetActive(true);
        MortPanel.SetActive(false);
        pausePanel.SetActive(false);
        
        globalVolume.enabled = false;
        _base.DOFade(0, 0.5f);
        amelioration.DOFade(1, 0.5f);
        StartCoroutine(PauseTime());
    }

    public void UnAmelioration()
    {
        basePanel.SetActive(true);
        ameliorationPanel.SetActive(false);
        MortPanel.SetActive(false);
        pausePanel.SetActive(false);
        
        globalVolume.enabled = true;
        _base.DOFade(1, 0.5f);
        amelioration.DOFade(0, 0.5f);
        StartCoroutine(UnPauseTime());
    }

    public void Mort()
    {
        SceneManager.LoadScene("Alois");
    }

    public void AnnonceMort()
    {
        basePanel.SetActive(false);
        ameliorationPanel.SetActive(false);
        MortPanel.SetActive(true);
        
        _base.DOFade(0, 0.5f);
        mort.DOFade(1, 0.5f);
        txtIndicationDeath.text = "Bon t'as quand même survecu pendant " + Chrono.instance.timer + " secondes et tu as fait " 
                                  + XP_Manager.instance.current_XP + " XP";
    }

    public void BtnAmelioration1()
    {
        //AddWeapon();
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

    public void AddWeapon()
    {
        DestroyBullet.instance.enabled = true;
    }
}
