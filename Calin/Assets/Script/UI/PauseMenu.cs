using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject creditMenuUI;
    
    public CanvasGroup pauseMenuCG;
    public CanvasGroup creditMenuCG;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");         //Nom de la scène du menu principal
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Alois");
    }

    public void Credit()
    { 
        pauseMenuCG.DOFade(0,0.2f);
        creditMenuCG.DOFade(1,0.2f);
    
        pauseMenuUI.SetActive(false);
        creditMenuUI.SetActive(true);
    }
    
    public void Menu()
    { 
        pauseMenuCG.DOFade(1,0.2f);
        creditMenuCG.DOFade(0,0.2f);
    
        pauseMenuUI.SetActive(true);
        creditMenuUI.SetActive(false);
    }
}
