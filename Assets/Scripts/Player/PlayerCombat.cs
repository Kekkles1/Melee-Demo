using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float attack;
    [SerializeField] float attackRange;

    public Transform attackPoint;
    public LayerMask layerMask;
    
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("AttackTrigger");

        Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layerMask);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attack);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
