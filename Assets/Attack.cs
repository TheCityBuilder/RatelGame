using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public ParticleSystem particles;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    void Update()
    {
        ParticleSystem particles = GetComponent<ParticleSystem>();
        if (Input.GetMouseButtonDown(0))
        {
            Attacks();
        }
    }

        void Attacks()
	    {

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            particles.Play();
        
            foreach (Collider2D enemy in hitEnemies)
            {
            enemy.GetComponent<Enemy>().TakeDamage(20);
            }
            
        }
        void OnDrawGizmosSelected()
        {
        if (attackPoint == null)
            return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
}
