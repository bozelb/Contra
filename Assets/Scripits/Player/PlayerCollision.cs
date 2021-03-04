using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMove))]

public class PlayerCollision : MonoBehaviour
    
{

    Rigidbody2D rb;
    PlayerMove player;
    Turret turret;

    public float bonusSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMove>();
        turret= GameObject.FindObjectOfType<Turret>();
        if (bonusSpeed <= 0)
            bonusSpeed = 20.0f;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TurretRaduis")
        {
            Debug.Log("Out of Range");
            turret.inDistance = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            if (!player.isGrounded)
            {
                Debug.Log("blood splatter");
                collision.gameObject.GetComponentInParent<Walker>().isHeadShot();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.right * bonusSpeed);
            }
        }
        if(collision.gameObject.tag == "TurretRaduis")
        {
            Debug.Log("IN Range");
            turret.inDistance = true;

        }
        if (collision.gameObject.tag == "Direction")
            collision.gameObject.GetComponentInParent<Turret>().flip();

    }
   
    
        
    }

