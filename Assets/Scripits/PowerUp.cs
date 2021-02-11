using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour

{
    public MachineGunPowerUp MGpowerUpPreFab;
    public Transform PowerUpSpawn;
   
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("DESTROY!!!!");

           
        }
        if (collision.gameObject.tag == "Projectile")
        {

            Destroy(this.gameObject);
            Debug.Log("DESTROY!!!!");

        }
    }
    private void OnDestroy()
    {
        Instantiate(MGpowerUpPreFab, PowerUpSpawn.position, PowerUpSpawn.rotation);


    }


}
