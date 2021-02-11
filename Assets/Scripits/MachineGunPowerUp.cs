using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class MachineGunPowerUp : MonoBehaviour
{

    
    private bool MGisOn = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MGisOn == true)
        {

            Debug.Log("is working");
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" || collision.gameObject.tag != "Projectile")
        {
           
            Destroy(this.gameObject);
            
        }
    }
    // Im trying to get the power up to actually work and inc amount of projectiles
   



}
