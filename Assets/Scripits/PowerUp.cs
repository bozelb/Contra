using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour
{

    public LifePowerUp lifeupPrefab;
    private int powerUpDecider;
    public MachineGun machineGunPreFab;
    public Shotgun shotgunPrefab;
    public Armor armorPrefab;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || (collision.gameObject.tag == "Projectile"))
        {
            PowerUpDecider();
            Destroy(this.gameObject);
        }
    }
    void PowerUpDecider()
    {
        powerUpDecider = Random.Range(1, 100);
        if (powerUpDecider > 0 && powerUpDecider < 30)
        {
            Instantiate(machineGunPreFab, transform.position, transform.rotation);
           

        }
        if (powerUpDecider >= 30 && powerUpDecider <= 60)
            {
                Instantiate(shotgunPrefab, transform.position, transform.rotation);
               
            }
        if (powerUpDecider >= 61 && powerUpDecider <=90)
        {
            Instantiate(armorPrefab, transform.position, transform.rotation);
            
        }
        if (powerUpDecider > 90)
        {
            Instantiate(lifeupPrefab, transform.position, transform.rotation);
            
        }
    }
    
}
