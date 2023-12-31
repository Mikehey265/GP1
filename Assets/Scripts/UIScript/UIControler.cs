using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SettingMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject lostMenu;
    [SerializeField] private GameObject startGameBtn;
    [SerializeField] private GameObject Overlay;


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
        MainMenu.SetActive(false);
        pauseMenu.SetActive(false);

    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        MainMenu.SetActive(false);
    }
   public void ResstartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
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
        if (MainMenu || SettingMenu || lostMenu)
        {
            MainMenu.SetActive(true);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);
        }
    }
    
    public void GameSetting()
    {
        MainMenu.SetActive(false);
        SettingMenu.SetActive(true) ;

    }
    public void Close()
    {

        if (MainMenu || pauseMenu || lostMenu || SettingMenu)
        {
            MainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);

            Time.timeScale = 1.0f;
        }
    }
}
