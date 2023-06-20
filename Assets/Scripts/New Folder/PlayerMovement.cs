using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpMag;
    public bool isGrounded;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 

        animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;

        // rb.velocity = transform.right * Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y)*Time.fixedDeltaTime;



        //rb.AddForce(rb.velocity, ForceMode2D.Force);

        //Vector2 move = transform.right * Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.fixedDeltaTime;
        //rb.AddForce(move, ForceMode2D.Force);

        //Work on the jumping please
        //Checks gamesplusjames for ground)


        //rb.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.fixedDeltaTime);
        //rb.AddForce(transform.up*Input.GetAxisRaw("Vertical")*JumpMag*Time.fixedDeltaTime);

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    rb.AddForce(transform.right * MoveSpeed * Time.fixedDeltaTime);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    rb.AddForce(transform.right * -MoveSpeed * Time.fixedDeltaTime);
        //}
    }
}
