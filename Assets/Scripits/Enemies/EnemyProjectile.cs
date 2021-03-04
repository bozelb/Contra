using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed = 7.0f;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        GetComponent<BoxCollider2D>();
        Destroy(gameObject, lifeTime);


        if (lifeTime <= 0)
        {
            lifeTime = 2.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
  

}


