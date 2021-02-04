using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    //Vars/Comps
     Rigidbody2D rb;
     Animator anim;
    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool isShooting;
    private bool isUp;
    private bool isDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
           
        }
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        //Flip Animation, 
        if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow))
        {

            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.eulerAngles = new Vector3(0, 0, 0);

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
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {

            isUp = true;
            anim.SetBool("IsUp", isUp);

        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) && isGrounded)
        {

            isUp = false;
            anim.SetBool("IsUp", isUp);

        }
        // Is shooting down, 
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {

            isDown = true;
            anim.SetBool("IsDown", isDown);

        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) && isGrounded)
        {

            isDown = false;
            anim.SetBool("IsDown", isDown);

        }

    }
}
