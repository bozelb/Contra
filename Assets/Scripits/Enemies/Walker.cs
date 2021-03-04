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

    public int health = 3;
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
       rb =  GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

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
            anim.SetBool("Death", true);
            rb.velocity = Vector2.zero;
        }
    }
    public void isHeadShot()
    {
       
        anim.SetBool("HeadShot", true);
        //rb.velocity = Vector2.zero;
    }
    public void finishedDeath()
    {
        Destroy(this.gameObject);
    }
}
