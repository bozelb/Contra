using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMove : MonoBehaviour
{
    //Vars/Comps
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer playerSprite;
    AudioSource jumpAudio;
     CrossHair crosshair;


    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public GameObject target;
    public Transform targetPos;
    public float groundCheckRadius;
    private bool isShooting;
    private bool isUp;
    private bool isDown;
    private bool isRight = true;
    public PowerUp powerUp;
    public Fire fire;
    int _score = 0;
    public GameManager game;



    public AudioClip jumpSFX;
    // Start is called before the first frame update
    void Start()
    {
        fire = GameObject.FindObjectOfType<Fire>();
        game = GameObject.FindObjectOfType<GameManager>();
        target = GameObject.Find("CrossHair");

         crosshair = target.GetComponent<CrossHair>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        
        if (speed <= 0)
        {
            speed = 5.0f;
            Debug.Log("Why you no work");
        }
        if(jumpForce <= 0)
        {

            jumpForce = 100;

        }
        if(groundCheckRadius <= 0)
        {

            groundCheckRadius = 0.1f;

        }
        if (!groundCheck)
        {

            Debug.Log("Ground CHeck does not exist, Please set a transform value for groundcheck");

        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            if (!jumpAudio)
            {
                jumpAudio = this.gameObject.AddComponent<AudioSource>();
                jumpAudio.clip = jumpSFX;
                jumpAudio.loop = false;
                jumpAudio.Play();
            }
            else
                jumpAudio.Play();
        }
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        //Flip Animation, 
        //The target in reference to the player is nega
        if (playerSprite.flipX && horizontalInput > 0 || !playerSprite.flipX && horizontalInput < 0)
        {

            playerSprite.flipX = !playerSprite.flipX;



        }
        //Shooting animation,
        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            isShooting = true;
            anim.SetBool("isShooting", isShooting);

        }
        if(Input.GetButtonUp("Fire1") && isGrounded)
        {

            isShooting = false;
            anim.SetBool("isShooting", isShooting);

        }
        //Shooting Up,
        if(crosshair.mouse_Pos.y > 0.5f && isGrounded)
        {

            isUp = true;
            anim.SetBool("IsUp", isUp);

        }
         /*if (target.position.y < 1.5f && isGrounded && isShooting == true)
        {

            isUp = false;
            anim.SetBool("IsUp", isUp);

        }
        // Is shooting down, 
        if (target.position.y < -1.5f && isGrounded && isShooting == true)
        {

            isDown = true;
            anim.SetBool("IsDown", isDown);

        }
        if (target.position.y > -1.5f && isGrounded && isShooting == true)
        {

            isDown = false;
            anim.SetBool("IsDown", isDown);

        }*/
       
    }

   

}
