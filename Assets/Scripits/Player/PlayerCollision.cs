using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMove))]

public class PlayerCollision : MonoBehaviour
    
{
    
    PlayerMove player;
    

    public float bonusSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            if (!player.isGrounded)
            {
                Debug.Log("blood splatter");
                collision.gameObject.GetComponentInParent<Walker>().isHeadShot();
               
            }
        }
        if (collision.gameObject.tag == "Death")
            GameManager.instance.subtract_Lives();
    }
       

    
   
    
        
    }

