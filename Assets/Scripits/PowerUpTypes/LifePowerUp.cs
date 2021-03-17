using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    public PlayerMove lives;
    private void Start()
    {
       lives = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Projectile")
            Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        //lives.lives++;
    }


}
