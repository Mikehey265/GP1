using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{

    [SerializeField] private GameObject Overlay;
    [SerializeField] private GameObject SettingMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject lostMenu;
    [SerializeField] private GameObject startGameBtn;
    [SerializeField] private GameObject DontKnowMenu;


    private bool optionsPicChange = false;


    private void Start()
    {

    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void Playe()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        DontKnowMenu.SetActive(false);

    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        Overlay.SetActive(false);
    }
   
    public void ExitGame()
    {
        if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
    public void BackToMainMenu()
    {
        if (Overlay || SettingMenu || lostMenu || DontKnowMenu)
        {
            Overlay.SetActive(true);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);
            DontKnowMenu.SetActive(false);
        }
    }
    public void BackToPauseMenue()
    {
        if (Overlay || pauseMenu || lostMenu || SettingMenu || DontKnowMenu)
        {
            Overlay.SetActive(false);
            pauseMenu.SetActive(true);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);
            DontKnowMenu.SetActive(false);
        }
    }
    public void GameSetting()
    {
        pauseMenu.SetActive(false);
        SettingMenu.SetActive(true) ;

    }
    public void Close()
    {

        if (Overlay || pauseMenu || lostMenu || SettingMenu || DontKnowMenu)
        {
            Overlay.SetActive(false);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);
            DontKnowMenu.SetActive(false);

            Time.timeScale = 1.0f;
        }
    }
}
