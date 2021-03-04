using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public float speed = 7.0f;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
        GetComponent<BoxCollider2D>();
        Destroy(gameObject, lifeTime);
       

       if(lifeTime <= 0)
        {
            lifeTime = 2.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3 || collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Walker>().isDead();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "EnemyTurret")
        {
            collision.gameObject.GetComponent<Turret>().isDead();
            Destroy(this.gameObject);
        }

    }
    //Have it destroy if hits anything but player, Since it'll never hit player this should work
    
   

}
