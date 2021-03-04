using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || (collision.gameObject.tag == "Projectile"))
        {

            Destroy(this.gameObject);
        }
    }
}
