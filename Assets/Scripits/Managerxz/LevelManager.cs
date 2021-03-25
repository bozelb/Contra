using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int starting_Lives = 3;
    
    public Transform starting_Position;

    AudioSource audio;
    public AudioClip level1SFX;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.turretCounter = 12;
        GameManager.instance.walkerCounter = 10;
        GameManager.instance.score = 0;
        GameManager.instance.Lives = 3;
        GameManager.instance.SpawnPlayer(starting_Position);
        GameManager.instance.currentLevel = this;
        Cursor.visible = false;

        playSound();

    }
    private void Update()
    {

      
    }

    public void playSound()
    {

        if (!audio)
        {
            audio = this.gameObject.AddComponent<AudioSource>();
            audio.volume = 0.5f;
            audio.clip = level1SFX;
            audio.Play();
        }
        else
            audio.Play();
    }

    public void stopSound()
    {
        audio.Stop();
    }

}
