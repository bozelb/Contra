using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Lives")]
    public Image lives1;
    public Image lives2;
    public Image lives3;

    [Header("Audio")]
    AudioSource audio;
    public AudioClip deathSFX;




    Canvas canvasImages;

    public GameObject PlayerPrefab;
    public GameObject playerInstance;
   public LevelManager currentLevel;
    static GameManager _instance = null;
    
    public static GameManager instance
    {

        get { return _instance; }
        set { _instance = value; }

    }
    int _turretCounter;
    public int turretCounter
    {
        get { return _turretCounter; }
        set
        {


            _turretCounter = value;
          /*   if (_turretCounter == 0)
       {
           Cursor.visible = true;
           SceneManager.LoadScene("GameComplete");
       
        }*/
      }
    }
    int _walkerCounter;
    public int walkerCounter
    {
        get { return _walkerCounter; }
        set
        {


            _walkerCounter = value;


        }

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
   
    int _lives = 3;
    public int Lives
    {
        get { return _lives; }
        set
        {
          
            _lives = value;
            
            
        }
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


        canvasImages = GameObject.FindObjectOfType<Canvas>();

    }
    public void subtract_Lives()

    {
        

        _lives = _lives - 1;
        

        if (!audio)
        {
            audio = this.gameObject.AddComponent<AudioSource>();
            audio.clip = deathSFX;
            audio.loop = false;
            audio.Play();
        }
        else
            audio.Play();
        if (Lives <= 0)
            Go_To_GameOver();

        Respawn();
    }
    public void  Go_To_GameOver()
    {

            SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
    }



    // Update is called once per frame
    void Update()

    {

        /* if (turretCounter == 0 && walkerCounter == 0)
         {
             Cursor.visible = true;
             SceneManager.LoadScene("GameComplete");
         }*/

        Debug.Log("Turret amount " + turretCounter);





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
        Debug.Log("lives are" +_lives) ;
        playerInstance.transform.position = currentLevel.starting_Position.position;
    }

    public void AddLife()
    {
        
    }
}
 