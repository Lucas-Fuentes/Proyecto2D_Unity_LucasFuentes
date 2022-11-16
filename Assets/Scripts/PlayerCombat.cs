using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator anim;
    public Transform attackHitbox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            anim.SetBool("isAttacking", true);
            Attack();
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void Attack()
    {
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackHitbox.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehaviour>().TakeDamage(1);
        }
    }

    /*
    void AttackBoss()
    {
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackHitbox.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehaviourBoss>().TakeDamage(1);
        }
    }
    */

    void OnDrawGizmosSelected()
    {
        if (attackHitbox == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackHitbox.position, attackRange);
    }

}
