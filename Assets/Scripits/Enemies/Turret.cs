using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Turret : MonoBehaviour
{
    public Transform SpawnPoint; //Where the projectile will spawn
    public EnemyProjectile enemyProjectilePreFab; //What will spawn
    public Transform Player;//To get the position of the player 
    public float turnSpeed = 1.0f;//How quickly the turret will move

    public float projectileForce = 5.0f;//How fast it will go
    public float projectileFireRate = 2;//Time in between shots

    float timeSincelastFired;//To track time since last fire, used later to make sure
    //It fires in the right time frame

    public int health;//how much damage it can take

    public bool inDistance;//Is it in the triggerBox to start shooting


    Animator anim;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        //Get animation for death and for sprite
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        //Fail safe incase the computer doesnt want to compute
        if (health <= 0)
            health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the position of the spawned playerprefab
        Player = GameObject.FindObjectOfType<CameraFollow>().Player.transform;
        //Is in distance? Then shoot & trigger rotation of turret
        if (inDistance == true)
        {
            RotateTowards(Player.position);
            //Setting the fire rate & set the spawn point for firing
            if (Time.time >= timeSincelastFired + projectileFireRate)
            {
                SpawnPointFire(Player.position);
                timeSincelastFired = Time.time;
                Fire();
            }
        }

    }

    //Fire function, basically will spawn the projectile
    public void Fire()
    { 
        EnemyProjectile temp = Instantiate(enemyProjectilePreFab, SpawnPoint.position, SpawnPoint.rotation);
        temp.speed = projectileForce;
    }
    //Blow UP!!!
    public void isDead()
    {
        anim.SetBool("Death", true);
    }
    //Destroy object, done in animation as event/Add 10 to score
    public void finishDeath()
    {
        GameManager.instance.score = GameManager.instance.score + 10;
        Destroy(this.gameObject);
    }
    //Rotating function for turret, called when in distance is true
    public void RotateTowards(Vector2 Player)
    {

        var offset = 180;
        Vector2 direction = Player - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    //Projectile spawn point, so it matches the turret rotation 
    public void SpawnPointFire(Vector2 Player)
    {
        Vector2 direction1 = Player - (Vector2)SpawnPoint.position;
        direction1.Normalize();
        enemyProjectilePreFab.projectileVector = direction1;
        //^^ Gets the vector enemyProjectile and makes it equal the unit vector direction1,
        //so when it fires it goes in the right direction
    }
}