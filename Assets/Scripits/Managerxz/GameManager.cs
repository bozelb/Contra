using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public GameObject PlayerPrefab;
    public GameObject playerInstance;
   public LevelManager currentLevel;
    static GameManager _instance = null;
    public static GameManager instance
    {

        get { return _instance; }
        set { _instance = value; }

    }
    int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {

            _score = value;
            Debug.Log("Current Score is " + _score);
        }

    }
    public int maxLives = 3;
    int _lives;
    public int lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value)
            {
                Respawn();
            }
            _lives = value;
            if (_lives > maxLives)
            {
                _lives = maxLives;
            }
            else if (_lives <= 0) { 
                //Go_To_GameOver();
                }
            Debug.Log("Current lives are " + _lives);
        }
    }
    public void subtract_Lives()
    {
        _lives = _lives - 1;
        Respawn();
        

    }

    public void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
            instance = this;
        DontDestroyOnLoad(this);

        Cursor.visible = false;
       
        
    }
    public void  Go_To_GameOver()
    {

            SceneManager.LoadScene("GameOver");

    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current lives are " + _lives);

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
            Quit_Game();
        }
        
    }


    public void SpawnPlayer(Transform spawnLocation)
    {
        CameraFollow mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        if (mainCamera)
        {
            mainCamera.Player = Instantiate(PlayerPrefab, spawnLocation.position, spawnLocation.rotation);
            playerInstance = mainCamera.Player;
        }
        
        else
            SpawnPlayer(spawnLocation);
    }
    
    public void Start_Game()
    {
        SceneManager.LoadScene("Level1");

    }
    public void Quit_Game()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;

#else
            Application.Quit();

#endif

    }
    public void Return_To_Menu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
public void Respawn()
    {
        playerInstance.transform.position = currentLevel.starting_Position.position;
    }
}
 