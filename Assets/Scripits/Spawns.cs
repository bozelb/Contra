using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUpPreFab;
    [SerializeField]
    private int howManySpawnPoints = 0;
    public GameObject[] spawnPoint;
    private int oldNumber;
    int[] r = new int[9];
    // Start is called before the first frame update
    void Start()
    {
        
        SpawnPowerUp();

    }
    void SpawnPowerUp()
    {

        for (int i = 0; i <= 4; i++)
        {
            /*   r[i] = Random.Range(0, 9);
              if(r[i] == oldNumber)
              {
                  r[i] = Random.Range(0, 9);
              }
              oldNumber = r[i];*/
            int r = i;
            Instantiate(powerUpPreFab, spawnPoint[r].transform.position, spawnPoint[r].
            transform.rotation);

        }
    }
   
 
        
        


    
    
    }


 