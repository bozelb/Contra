using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUpPreFab;
    [SerializeField]
    private int howManySpawnPoints = 5;
    public GameObject[] spawnPoint;
    int[] r;
    // Start is called before the first frame update
    void Start()
    {
        
        SpawnPowerUp();

    }
    void SpawnPowerUp()
    {
        for (int k = 0; k < 4; k++)
        {
            Instantiate(powerUpPreFab, spawnPoint[k].transform.position, spawnPoint[k].
            transform.rotation);
        }   
    
    }
   
        
        


    
    
    }


 