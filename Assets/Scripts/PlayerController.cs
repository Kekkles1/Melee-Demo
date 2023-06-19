using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float RunSpeed;
    public float JumpSpeed;

    private SpriteRenderer spriteRenderer;
    private CharacterController characterController;
    private Animator animator;
    private Vector3 move;

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

        move = new Vector3(x, y, 0);
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
