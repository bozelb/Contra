using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Walker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRender;
    Animator anim;
    BoxCollider2D boxCollider;

    AudioSource audio;
    public AudioClip deathSFX;
    public AudioClip splatSFX;
    

    public int health = 3;
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
       rb =  GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (speed <= 0.0f)
            speed = 5.0f;

        if (health < 0)
            health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Death") && !anim.GetBool("HeadShot"))
        {
            if (spriteRender.flipX == true)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            spriteRender.flipX = !spriteRender.flipX;
        }
    }

        public void isDead()
    {

        health--;
        if(health <= 0)
        {

            playSound(deathSFX);
            boxCollider.enabled = false;
            anim.SetBool("Death", true);
            rb.velocity = Vector2.zero;
        }
    }
    public void isHeadShot()
    {
        playSound(splatSFX);
        boxCollider.enabled = false;
        anim.SetBool("HeadShot", true);
        //rb.velocity = Vector2.zero;
    }
    public void finishedDeath()
    {
        GameManager.instance.score = GameManager.instance.score + 10;
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        GameManager.instance.walkerCounter = GameManager.instance.walkerCounter - 1;

    }
    public void playSound(AudioClip someSound)
    {

        if (!audio)
        {
            audio = this.gameObject.AddComponent<AudioSource>();
            audio.clip = someSound;
            audio.loop = false;
            audio.Play();
        }
        else
            audio.Play();
    }

}
