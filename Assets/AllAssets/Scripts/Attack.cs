using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attacks();
        }
    }

    private void Attacks()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        particles.Play();
        
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }
        
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
