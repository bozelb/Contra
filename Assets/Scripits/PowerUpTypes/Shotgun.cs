using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Fire fire;

    private void Start()
    {
        fire = GameObject.FindObjectOfType<Fire>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fire.scatterShoot = true;
            Destroy(this.gameObject);
        }
    }
}
