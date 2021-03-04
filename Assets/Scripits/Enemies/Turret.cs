using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Turret : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform SpawnPoint2;
    public EnemyProjectile enemyProjectilePreFab;
    public Transform Player;

    public float projectileForce;
    public float projectileFireRate = 2;

    float timeSincelastFired;
    public int health;

    public bool inDistance;
    

    Animator anim;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if (projectileForce <= 0)
            projectileForce = 7.0f;

        if (health <= 0)
            health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (inDistance == true)
        {
           
            if (Time.time >= timeSincelastFired + projectileFireRate)
            {
                timeSincelastFired = Time.time;
                Fire();
            }
        }
        
    }
    public void Fire()
    {
        
        if (sprite.flipX)
        {
            Debug.Log("Turret fire");
            EnemyProjectile temp = Instantiate(enemyProjectilePreFab, SpawnPoint2.position, SpawnPoint2.rotation);
            temp.speed = projectileForce;
        }
        else
        {
            
            EnemyProjectile temp = Instantiate(enemyProjectilePreFab, SpawnPoint.position, SpawnPoint.rotation);
            temp.speed = projectileForce * -1;
        }
    }
    public void isDead()
    {
        anim.SetBool("Death", true);
    }
    public void finishDeath()
    {
        Destroy(this.gameObject);
    }
    public void flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}  
