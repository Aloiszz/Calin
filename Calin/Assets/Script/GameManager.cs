using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;
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

    public TextMeshProUGUI btn1;
    public TextMeshProUGUI btn2;
    public TextMeshProUGUI btn3;

    public TextMeshProUGUI txtIndicationDeath;
    
    public static GameManager instance;

    public bool isVoileBlanc;
    public Image voileBlanc;
    
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
        /*BtnAmelioration1();
        BtnAmelioration2();
        BtnAmelioration3();*/
    }

    private void Start()
    {
        
        Shotgun.instance.velocityIndex = 0;
        Shotgun.instance.cadencyIndex = 0;
        Shotgun.instance.axeShootIndex = 0;
        Shotgun.instance.numberIndex = 0;
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

        if (isVoileBlanc)
        {
            StartCoroutine(VoileBlanc());
        }
    }

    IEnumerator VoileBlanc()
    {
        voileBlanc.GetComponent<Image>().DOFade(1, 0.2f);
        yield return new WaitForSeconds(1.5f);
        voileBlanc.GetComponent<Image>().DOFade(0, 0.5f);
        isVoileBlanc = false;
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
        
        hazard();
        hazard2();
        hazard3();
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
    private int result;
    private int result2;
    private int result3;
    void hazard()
    {
        result = Random.Range(0, 3);
        Debug.Log(result);

        switch (result)
        {
            case 0 :
                btn1.text = axeDeTireTXT;
                break;
            case 1 :
                btn1.text = addVelocityTXT;;
                break;
            case 2 :
                btn1.text = addNbrBalleTXT;
                break;
            case 3 :
                btn1.text = addCadencyTXT;
                break;
        }
    }
    void hazard2()
    {
        result2 = Random.Range(0, 3);
        Debug.Log(result);

        switch (result2)
        {
            case 0 :
                btn2.text = axeDeTireTXT;
                break;
            case 1 :
                btn2.text = addVelocityTXT;
                break;
            case 2 :
                btn2.text = addNbrBalleTXT;
                break;
            case 3 :
                btn2.text = addCadencyTXT;
                break;
        }
    }
    void hazard3()
    {
        result3 = Random.Range(0, 3);
        Debug.Log(result);

        switch (result3)
        {
            case 0 :
                btn3.text = axeDeTireTXT;
                break;
            case 1 :
                btn3.text = addVelocityTXT;;
                break;
            case 2 :
                btn3.text = addNbrBalleTXT;
                break;
            case 3 :
                btn3.text = addCadencyTXT;
                break;
        }
    }

    public void BtnAmelioration1()
    {
        //AddWeapon();
        //hazard();
        switch (result)
        {
            case 0 :
                AxeDeTire();
                break;
            case 1 :
                AddVelocity();
                break;
            case 2 :
                AddNumber();
                break;
            case 3 :
                AddCadency();
                break;
        }
    }
    
    public void BtnAmelioration2()
    {
        //AddVelocity();
        //hazard2();
        switch (result2)
        {
            case 0 :
                AxeDeTire();
                break;
            case 1 :
                AddVelocity();
                break;
            case 2 :
                AddNumber();
                break;
            case 3 :
                AddCadency();
                break;
        }
    }
    
    public void BtnAmelioration3()
    {
        //AddNumber();
        //hazard3();
        switch (result3)
        {
            case 0 :
                AxeDeTire();
                break;
            case 1 :
                AddVelocity();
                break;
            case 2 :
                AddNumber();
                break;
            case 3 :
                AddCadency();
                break;
        }
    }
    
    /*-------------------------Amelioration-----------------------------------------*/
    private string axeDeTireTXT = "Ajouts d'un axe de tire";
    private string addVelocityTXT = "Augmente la vélocité des munitions tirées";
    private string addNbrBalleTXT = "Augmente le nombre de balles tirées";
    private string addCadencyTXT = "Augmente la cadence de tire";
    
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
