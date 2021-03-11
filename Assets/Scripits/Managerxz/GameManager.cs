using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public static GameManager instance
    {

        get { return _instance; }
        set { _instance = value; }

    }


    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
            instance = this;
        

        
    }
    public void  Go_To_GameOver()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
            SceneManager.LoadScene("GameOver");

    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "Level1")
            SceneManager.LoadScene("TitleScreen");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "TitleScreen")
             SceneManager.LoadScene("Level1");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "GameOver")
                SceneManager.LoadScene("TitleScreen");
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;

#else
            Application.Quit();

#endif
        }
    }
 }
 