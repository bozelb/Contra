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
    public float projectileSpeed = 7.0f;
    public Projectile projectilePrefab;
    public bool machineGunPower = false;
    public PlayerMove timer;
    public float projectileFireRate = 5.0f;
   
    bool cannotShoot = false;
    public Transform target;
    Vector2 scatter;
    bool defaultShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        GetComponent<BoxCollider2D>();
        timer = GameObject.FindObjectOfType<PlayerMove>();
        if (!spawnRight || !spawnLeft || !projectilePrefab)
        {

            Debug.Log("Unity Inspector value not set");

        }
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindObjectOfType<CrossHair>().transform;

        if(defaultShoot == true)
        ShootController(target.position);
        if (machineGunPower == true)
        {
            defaultShoot = false;
            StartCoroutine(PowerUpTimer());
            MachineGun(target.position);
        }
        //ScatterGun();
    }
    public void ShootController(Vector2 target)
    {
        Vector2 direction1 = target - (Vector2)transform.position;
        direction1.y = direction1.y - 0.75f;
        direction1.Normalize();
        projectilePrefab.projectileVector = direction1;
        if (Input.GetButtonDown("Fire1"))
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
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
                cannotShoot = true;
                StartCoroutine(ShootDelay());
                Projectile projectileInstance = Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
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
        defaultShoot = true;
    }


    public void ScatterGun()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        scatter = new Vector2(0.0f, 0.5f);
                        projectilePrefab.projectileVector = scatter;
                        Projectile projectileInstance = Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
                        projectileInstance.speed = projectileSpeed;
                        break;
                    case 2:
                        scatter = new Vector2(4.0f, 0.5f);
                        projectilePrefab.projectileVector = scatter;
                        Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
                        break;
                    case 3:
                        scatter = new Vector2(6.0f, 0.5f);
                        projectilePrefab.projectileVector = scatter;
                        Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
                        break;
                    case 4:
                        scatter = new Vector2(-0.0f, 0.5f);
                        projectilePrefab.projectileVector = scatter;
                        Instantiate(projectilePrefab, spawnRight.position, spawnRight.rotation);
                        break;

                }

            }
        }

    }
    
}


