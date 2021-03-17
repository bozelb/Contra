using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //Getting Scripts to use their vars
    public GameManager manager;
    public Turret turret;

    //Setting speed and Vectors
    public float speed = 4.0f;
    public Vector2 projectileVector; //This vector is set in Turret script in function SpawnPointFire
    public float lifeTime;//How long to exisit

    // Start is called before the first frame update
    void Start()    
    {   //Setting the force on the rb so it goes fast like Sonic
        GetComponent<Rigidbody2D>().velocity = projectileVector * speed;
        //Just getting componets
        GetComponent<BoxCollider2D>();
        Destroy(gameObject, lifeTime);
        manager = GameObject.FindObjectOfType<GameManager>();
        //Fail Safe, for lifetime
        if (lifeTime <= 0)
        {
            lifeTime = 2.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Make the player Take damage on Hit, references GameManger subtract lives
        if(collision.gameObject.tag == "Player")
        {
            manager.subtract_Lives();
            Destroy(this.gameObject);
        }
    }
}


