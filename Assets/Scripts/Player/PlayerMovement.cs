using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float MoveSpeed;
    [SerializeField] public float JumpMag;
    private bool isGrounded;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = checkGrounded();
    

        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            animator.SetTrigger("JumpTrigger");

        }
        //animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }

    private void Move()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0, JumpMag);
    }
    private bool checkGrounded()
    {
        //return boxCollider.IsTouchingLayers(LayerMask.NameToLayer("Ground"));
        //return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, whatIsGround);
        return Physics2D.IsTouchingLayers(boxCollider, whatIsGround);
    }
}
