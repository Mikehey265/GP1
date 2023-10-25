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
    [SerializeField] private GameObject DontKnowMenu;
    //[SerializeField] private GameObject lostImage;


    //[SerializeField] private Sprite closeImage;
    //[SerializeField] private Sprite pauseImage;
    //[SerializeField] private Sprite playImage;
    //[SerializeField] private Sprite resultImage;

    //[SerializeField] private TextMeshProUGUI resultText;
    //[SerializeField] private TextMeshProUGUI motivationText;
    private bool optionsPicChange = false;


    private void Start()
    {

    }
    //public void Options()
    //{
    //    Image _playImage = startGameBtn.GetComponent<Image>();
    //    _playImage.sprite = playImage;

    //    if (!MainMenu.active)
    //    {
    //        MainMenu.SetActive(true);
    //        lostMenu.SetActive(false);
    //        Time.timeScale = 0.0f;
    //        _playImage.sprite = playImage;
    //        //_playImage.sprite.name = "PlayBtn";
    //    }
    //}



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
        MainMenu.SetActive(false);
    }
    //public void LoadingNextScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    Time.timeScale = 1.0f;
    //}
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
        if (MainMenu || SettingMenu || lostMenu || DontKnowMenu)
        {
            MainMenu.SetActive(true);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);
            DontKnowMenu.SetActive(false);
        }
    }
    public void BackToPauseMenue()
    {
        if (MainMenu || pauseMenu || lostMenu || SettingMenu || DontKnowMenu)
        {
            MainMenu.SetActive(false);
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

        if (MainMenu || pauseMenu || lostMenu || SettingMenu || DontKnowMenu)
        {
            MainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            lostMenu.SetActive(false);
            SettingMenu.SetActive(false);
            DontKnowMenu.SetActive(false);

            Time.timeScale = 1.0f;
        }
    }
}
