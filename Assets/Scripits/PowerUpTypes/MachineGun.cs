using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    //Get access to Fire to change projectile 
    public Fire fire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            fire = collision.gameObject.GetComponent<Fire>();
            fire.machineGunPower = true;
            Destroy(this.gameObject);
        }
    }
}
