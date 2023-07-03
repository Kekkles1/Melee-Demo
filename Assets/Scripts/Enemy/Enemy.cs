using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float attack;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        boxCollider=GetComponent<BoxCollider2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        //play animation
        hp -= damage;


        if (hp<=0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
