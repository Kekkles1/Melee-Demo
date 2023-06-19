using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float RunSpeed;
    public float JumpMag;
    private float gravity=-9.81f;

    private SpriteRenderer spriteRenderer;
    private CharacterController characterController;
    private Animator animator;
    private Vector3 playerVelocity;         //for jumping

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, y, 0);

        if (move.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;

        animator.SetFloat("speed", Mathf.Abs(x));
        //set animator for jump here
        characterController.Move(move * Time.fixedDeltaTime * RunSpeed);
    }
  
}
