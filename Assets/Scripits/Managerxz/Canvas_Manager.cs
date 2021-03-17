using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_Manager : MonoBehaviour
{
    [Header("Buttons")]
    public Button start_Button;
    public Button Quit_Button;
    public Button return_To_Menu;
    public Button return_To_Game;
    public Button settings;
    public Button BackButton;

    [Header("Menus")]
    public GameObject pause_Menu;
    public GameObject main_Menu;
    public GameObject settings_Menu;
   
    [Header("TextBox")]
    public Text livesText;
    public Text scoreCounter;
    public Text sliderCounter;
    public Text muteText;

    [Header("Slider")]
    public Slider volSlider;

    [Header("CheckBox")]
    public Toggle mute;

    // Start is called before the first frame update
    void Start()
    {
        

        if (pause_Menu)
        {
            pause_Menu.SetActive(false);
        }
        if (start_Button)
        {
            start_Button.onClick.AddListener(() => GameManager.instance.Start_Game());
        }
        if (Quit_Button)
        {
            Quit_Button.onClick.AddListener(() => GameManager.instance.Quit_Game());
        }
        if (return_To_Game)
        {
            return_To_Game.onClick.AddListener(() => Return_To_Game());
        }
        if (return_To_Menu)
        {
            return_To_Menu.onClick.AddListener(() => Return_To_Menu());
        }
        if (BackButton)
        {
            BackButton.onClick.AddListener(() => ShowMainMenu());
        }
        if (settings)
        {
            settings.onClick.AddListener(() => ShowSettingsMenu());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (settings_Menu)
        {
            if (settings_Menu.activeSelf)
                sliderCounter.text = volSlider.value.ToString();
            if (mute.isOn)
            {
                muteText.text = "Unmute";
            }
            else
            {
                muteText.text = "Mute";
            }
        }
        
        if (pause_Menu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pause_Menu.SetActive(true);
                Time.timeScale = 0;
                
            }
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (pause_Menu.activeSelf)
            {
                sliderCounter.text = volSlider.value.ToString();
                if (mute.isOn)
                {
                    muteText.text = "Unmute";
                }
                else
                {
                    muteText.text = "Mute";
                }
            }
        }

        if (livesText)
        {
            livesText.text = GameManager.instance.lives.ToString();
        }
        if (scoreCounter)
        {
            scoreCounter.text = GameManager.instance.score.ToString();
        }
               
        
    }

    public void Return_To_Game()
    {
        pause_Menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Return_To_Menu()
    {
        pause_Menu.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.score = 0;
        GameManager.instance.Return_To_Menu();
    }

    void ShowMainMenu()
    {
        main_Menu.SetActive(true);
        settings_Menu.SetActive(false);
    }
    void ShowSettingsMenu()
    {
        settings_Menu.SetActive(true);
        main_Menu.SetActive(false);
        
       
    }
}
