using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour
{
    //Prefabs of powerups
    public LifePowerUp lifeupPrefab;
    
    public MachineGun machineGunPreFab;
    public Shotgun shotgunPrefab;
    public Armor armorPrefab;

    //A number that decides which prefab will spawn
    private int powerUpDecider;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        //Get componet
        GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Projectile")
        {
            PowerUpDecider();//Runs function to pick powerup/Add score//Destroy
            GameManager.instance.score = GameManager.instance.score + 5;
            Destroy(this.gameObject);
        }
    }
    void PowerUpDecider()
    {
        powerUpDecider = Random.Range(1, 100); //Picks from a ranage of 100
        if (powerUpDecider > 0 && powerUpDecider < 50)
        {
            Instantiate(machineGunPreFab, transform.position, transform.rotation);
           

        }
        if (powerUpDecider >= 51 && powerUpDecider <= 100)
            {
                Instantiate(shotgunPrefab, transform.position, transform.rotation);
               
            }
       /* if (powerUpDecider >= 61 && powerUpDecider <=90)
        {
            Instantiate(armorPrefab, transform.position, transform.rotation);
            
        }
        if (powerUpDecider > 90)
        {
            Instantiate(lifeupPrefab, transform.position, transform.rotation);
            
        }*/
    }
    
}
