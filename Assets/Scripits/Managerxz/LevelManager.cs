using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int starting_Lives;
    public Transform starting_Position;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.lives = starting_Lives;
        GameManager.instance.SpawnPlayer(starting_Position);
        GameManager.instance.currentLevel = this;
    }
}
