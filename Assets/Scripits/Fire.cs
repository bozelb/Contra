using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Fire : MonoBehaviour
{
    SpriteRenderer player;
    public Transform spawnRight;
    public Transform spawnLeft;
    public float projectileSpeed;
    public Projectile projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        GetComponent<BoxCollider2D>();
        if (!spawnRight || !spawnLeft || !projectilePrefab)
        {

            Debug.Log("Unity Inspector value not set");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
            Debug.Log("is fire");
        }
    }
    void FireProjectile()
    {
        // Create bullet and have it flip depending on which way player facing
        if(player.flipX)
        {
            // * by -1 to have it to flip direction
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnLeft.position, spawnLeft.rotation);
            projectileInstance.speed = projectileSpeed * -1;
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
            projectileInstance.speed = projectileSpeed;
        }
    }
   

}


