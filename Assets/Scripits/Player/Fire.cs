using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Fire : MonoBehaviour
{
    //Transform for spawn points and unit vectors for projectile
    [Header("Transform")]
    public Transform spawnRight;
    public Transform spawnLeft;
    public Transform spawn;
    public Transform target;

    //Timer for how long powerups will stay
    [Header("Ref to other scripts")]
    public PlayerMove timer;
   

    //Projectile 
    [Header("Projectile properties")]
    public float projectileSpeed = 7.0f;
    public Projectile projectilePrefab;
    public float projectileFireRate = 5.0f;

    //Powerup bools, to dictate whether they are on or not
    [Header("Bools for powerups")]
    public bool machineGunPower = false;
    bool cannotShoot = false;
    bool defaultShoot = true;
       public bool scatterShoot = false;

    //Audio
    [Header("Audio")]
    AudioSource shootAudio;
    public AudioClip shootSFX;


    // Start is called before the first frame update
    void Start()
    {
        //Get compoents
        GetComponent<BoxCollider2D>();
        timer = GameObject.FindObjectOfType<PlayerMove>();
        if (!spawnRight || !projectilePrefab)
        {

            Debug.Log("Unity Inspector value not set");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Find the target every frame so the bullets go the right way
        target = GameObject.FindObjectOfType<CrossHair>().transform;
       
        //DefaultShoot to stop other powerup
       if(defaultShoot == true)
        ShootController(target.position);

        if (machineGunPower == true)
        {
            defaultShoot = false;
            scatterShoot = false;
            StartCoroutine(PowerUpTimer());
            MachineGun(target.position);
        }

        if (scatterShoot == true)
        {
            defaultShoot = false;
            machineGunPower = false;
            StartCoroutine(PowerUpTimer());
            ScatterGun(target.position);
        }
    }
    public void ShootController(Vector2 target)
    {
       


        Vector2 direction1 = target - (Vector2)transform.position;
        direction1.y = direction1.y - 0.75f;
        direction1.Normalize();
        projectilePrefab.projectileVector = direction1;
        if (Input.GetButtonDown("Fire1"))
        {
            playShootSound();
            Projectile projectileInstance = Instantiate(projectilePrefab, spawn.position, spawn.rotation);
            projectileInstance.speed = projectileSpeed;
        }

    }
    public void MachineGun(Vector2 target)
    {
        
        Vector2 direction1 = target - (Vector2)transform.position;
        direction1.y = direction1.y - 0.75f;
        direction1.Normalize();
        projectilePrefab.projectileVector = direction1;
        if (Input.GetButton("Fire1"))
        {
            if (cannotShoot == false)
            {
                playShootSound();
                cannotShoot = true;
                StartCoroutine(ShootDelay());
                Projectile projectileInstance = Instantiate(projectilePrefab, spawn.position, spawn.rotation);
                projectileInstance.speed = projectileSpeed;
            }
           
        }

    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(0.1f);
        cannotShoot = false;
    }
    IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(5);
        machineGunPower = false;
        scatterShoot = false;
        defaultShoot = true;
    }


    public void ScatterGun(Vector2 target)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playShootSound();

            //Get unit vector
            Vector2 scatter1 = target - (Vector2)transform.position;
            scatter1.Normalize();
            projectilePrefab.projectileVector = scatter1;
           

            //Create projectile,
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
            projectileInstance.speed = projectileSpeed;

            //Get unit vector
            Vector2 scatter2 = target - (Vector2)transform.position;
            scatter2.y = scatter2.y + 0.35f;
            scatter2.Normalize();
            projectilePrefab.projectileVector = scatter2;
           //Find two angles,

            //Create projectile,
            projectileInstance = Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
            projectileInstance.speed = projectileSpeed;

            //Get unit vector
            Vector2 scatter3 = target - (Vector2)transform.position;
            scatter3.y = scatter3.y - 0.35f;
            scatter3.Normalize();
            projectilePrefab.projectileVector = scatter3;
            //Find two angles,

            //Create projectile,
            projectileInstance = Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
            projectileInstance.speed = projectileSpeed;


        }

    }

    public void playShootSound()
    {
        if (!shootAudio)
        {
            shootAudio = this.gameObject.AddComponent<AudioSource>();
            shootAudio.clip = shootSFX;
            shootAudio.loop = false;
            shootAudio.Play();
        }
        else
            shootAudio.Play();
    }
    
}


